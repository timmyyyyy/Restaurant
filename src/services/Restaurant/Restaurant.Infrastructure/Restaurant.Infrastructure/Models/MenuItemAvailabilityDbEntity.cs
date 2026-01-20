using System.Text.Json;
using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;
using Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes;

namespace Restaurant.Infrastructure.Models;

public class MenuItemAvailabilityDbEntity : BaseDbEntitySoftDeletable
{
    internal MenuItemAvailabilityDbEntity() { }

    public MenuItemAvailabilityType MenuItemAvailabilityType { get; set; }

    public required string ItemAvailabilityJSON { get; set; }

    public static explicit operator MenuItemAvailability(MenuItemAvailabilityDbEntity entity)
    {
        var serializerOptions = new JsonSerializerOptions();
        serializerOptions.Converters.Add(new MenuItemAvailabilityJsonConverter());

        return JsonSerializer.Deserialize<MenuItemAvailability>(entity.ItemAvailabilityJSON, serializerOptions)!;
    }
}
