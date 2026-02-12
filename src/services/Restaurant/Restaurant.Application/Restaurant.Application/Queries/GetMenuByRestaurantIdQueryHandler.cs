using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Dtos;
using Restaurant.Domain.Aggregates.Menu;
using Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes;
using Restaurant.Infrastructure;

namespace Restaurant.Application.Queries;

public class GetMenuByRestaurantIdQueryHandler : IRequestHandler<GetMenuByRestaurantIdQuery, MenuDto?>
{
    private readonly RestaurantDbContext _dbContext;

    public GetMenuByRestaurantIdQueryHandler(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<MenuDto?> Handle(GetMenuByRestaurantIdQuery request, CancellationToken cancellationToken)
    {
        var menuEntity = await _dbContext.Menus
            .Include(x => x.Items)
                .ThenInclude(y => y.ItemCategory)
            .Include(x => x.Items)
                .ThenInclude(y => y.Availability)
            .FirstOrDefaultAsync(x => x.RestaurantId == request.RestaurantId, cancellationToken);

        if (menuEntity == null)
            return null;

        var menu = (Menu)menuEntity;

        var itemsByCategory = menu.Items
            .GroupBy(x => x.ItemCategory)
            .Select(y => new MenuCategoryDto
            {
                Id = y.Key.Id,
                Name = y.Key.CategoryName,
                Items = [.. y.Select(z => new MenuItemDto
                {
                    Id = z.Id,
                    Name = z.Name,
                    Description = z.Description,
                    Price = z.Price,
                    IsCurrentlyAvailable = z.IsAvailable(),
                    UnavailabilityReason = BuildUnavailabilityMessage(z),
                    Availability = [.. z.Availability.Select(a => MapAvailability(a))]
                })]
            }).ToList();

        return new MenuDto
        {
            Id = menu.Id,
            RestaurantId = menu.RestaurantId,
            Categories = itemsByCategory
        };
    }

    private static MenuItemAvailabilityDto MapAvailability(MenuItemAvailability availability)
    {
        return new MenuItemAvailabilityDto
        {
            Type = availability.MenuItemAvailabilityType,
            Data = MapAvailabilityData(availability)
        };
    }

    private static string BuildUnavailabilityMessage(MenuItem item)
    {
        if (item.IsAvailable())
            return string.Empty;

        if (item.IsCurrentlyDisabled)
            return "This item is temporarily unavailable";

        var failedReasons = new List<string>();

        foreach (var rule in item.Availability)
        {
            if (!rule.IsCurrentlyAvailable())
            {
                var reason = rule switch
                {
                    MenuItemHoursOfDayAvailability hours 
                        => $"Available only between {hours.StartTime:HH:mm} - {hours.EndTime:HH:mm}",
                    MenuItemDaysOfWeekAvailability days 
                        => $"Available only on {string.Join(", ", days.DaysOfWeek)}",
                    MenuItemDatePeriodAvailability period 
                        => $"Available from {period.StartDate:yyyy-MM-dd} to {period.EndDate:yyyy-MM-dd}",
                    MenuItemSpecificDatesAvailability dates 
                        => "Available only on specific dates",
                    _ => null
                };

                if (reason != null)
                    failedReasons.Add(reason);
            }
        }

        return failedReasons.Count > 0 
            ? string.Join(". ", failedReasons) 
            : "This item is currently unavailable";
    }

    private static object? MapAvailabilityData(MenuItemAvailability availability)
    {
        return availability switch
        {
            MenuItemHoursOfDayAvailability hours => new
            {
                startTime = hours.StartTime.ToString("HH:mm"),
                endTime = hours.EndTime.ToString("HH:mm")
            },
            MenuItemDaysOfWeekAvailability days => new
            {
                daysOfWeek = days.DaysOfWeek.Select(d => d.ToString()).ToList()
            },
            MenuItemDatePeriodAvailability period => new
            {
                startDate = period.StartDate.ToString("yyyy-MM-dd"),
                endDate = period.EndDate.ToString("yyyy-MM-dd")
            },
            MenuItemSpecificDatesAvailability dates => new
            {
                specificDates = dates.SpecificDates.Select(d => d.ToString("yyyy-MM-dd")).ToList()
            },
            _ => null
        };
    }
}

