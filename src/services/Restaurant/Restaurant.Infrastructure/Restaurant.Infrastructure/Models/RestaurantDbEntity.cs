using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;
using Restaurant.Domain.Aggregates.Restaurant;

namespace Restaurant.Infrastructure.Models;

public class RestaurantDbEntity : BaseDbEntitySoftDeletable
{
    internal RestaurantDbEntity() { }

    public required string Name { get; set; }

    public required AddressDbEntity Address { get; set; }

    public required IEnumerable<WorkingScheduleDbEntity> WorkingSchedule { get; set; }

    public required IEnumerable<MenuDbEntity> Menus { get; set; }

    public static explicit operator Domain.Aggregates.Restaurant.Restaurant(RestaurantDbEntity entity)
    {
        return new()
        {
            Id = entity.Id,
            MenuIds = entity.Menus?.Select(x => x.Id)?.ToList() ?? Enumerable.Empty<Guid>(),
            Name = entity.Name,
            Address = (Address)entity.Address,
            WorkingSchedule = WorkingScheduleDbEntity.ToWorkingScheduleDomainObject(entity.WorkingSchedule),
        };
    }
}
