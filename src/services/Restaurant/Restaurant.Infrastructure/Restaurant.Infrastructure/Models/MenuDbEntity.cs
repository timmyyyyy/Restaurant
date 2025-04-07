using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;
using Restaurant.Domain.Aggregates.Menu;

namespace Restaurant.Infrastructure.Models
{
    public class MenuDbEntity : BaseDbEntitySoftDeletable
    {
        public string Name { get; set; }

        public RestaurantDbEntity Restaurant { get; set; }

        public Guid RestaurantId { get; set; }

        public IEnumerable<MenuItemDbEntity> Items { get; set; }

        public static explicit operator Menu(MenuDbEntity entity)
            => new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Items = entity.Items.Select(x => (MenuItem)x)
            };
    }
}
