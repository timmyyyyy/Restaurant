using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;
using Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes;
using System.Text.Json;

namespace Restaurant.Infrastructure.Models
{
    public class MenuItemAvailabilityDbEntity : BaseDbEntitySoftDeletable
    {
        public MenuItemAvailabilityType MenuItemAvailabilityType { get; set; }

        public string ItemAvailabilityJSON { get; set; }

        public static explicit operator MenuItemAvailability(MenuItemAvailabilityDbEntity entity)
        {
            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new MenuItemAvailabilityJsonConverter());

            return JsonSerializer.Deserialize<MenuItemAvailability>(entity.ItemAvailabilityJSON, serializerOptions)!;
        }
    }
}
