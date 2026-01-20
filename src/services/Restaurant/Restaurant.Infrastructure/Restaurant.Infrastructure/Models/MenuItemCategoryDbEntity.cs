using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;
using Restaurant.Domain.Aggregates.Menu;

namespace Restaurant.Infrastructure.Models;

public class MenuItemCategoryDbEntity : BaseDbEntitySoftDeletable
{
    internal MenuItemCategoryDbEntity() { }

    public required string CategoryName { get; set; }

    public static explicit operator MenuItemCategory(MenuItemCategoryDbEntity entity)
        => new() { CategoryName = entity.CategoryName };
}
