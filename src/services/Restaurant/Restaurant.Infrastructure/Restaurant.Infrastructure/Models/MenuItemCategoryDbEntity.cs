using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;
using Restaurant.Domain.Aggregates.Menu;

namespace Restaurant.Infrastructure.Models
{
    public class MenuItemCategoryDbEntity : BaseDbEntitySoftDeletable
    {
        public string CategoryName { get; set; }

        public static explicit operator MenuItemCategory(MenuItemCategoryDbEntity entity)
            => new MenuItemCategory() { CategoryName = entity.CategoryName };
    }
}
