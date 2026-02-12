using System.Text.Json.Serialization;
using Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes;

namespace Restaurant.Application.Dtos;

public class MenuDto
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public List<MenuCategoryDto> Categories { get; set; } = new();
}

public class MenuCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<MenuItemDto> Items { get; set; } = new();
}

public class MenuItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool IsCurrentlyAvailable { get; set; }
    public string? UnavailabilityReason { get; set; }
    public List<MenuItemAvailabilityDto> Availability { get; set; } = new();
}

public class MenuItemAvailabilityDto
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MenuItemAvailabilityType Type { get; set; }
    public object? Data { get; set; }
}
