using System.Threading;
using Microsoft.EntityFrameworkCore;
using Restaurant.Common;
using Restaurant.Common.ApplicationBuildingBlocks;
using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;
using Restaurant.Domain.Aggregates.Menu;

namespace Restaurant.Infrastructure.Repositories;

public class MenuRepository(RestaurantDbContext context) : IMenuRepository
{
    public async Task<OperationResult<Menu>> GetMenu(Guid id, CancellationToken cancellationToken = default)
    {
        var menu = await context.Menus
            .AsNoTracking()
            .Include(x => x.Items)
                .ThenInclude(x => x.Availability)
            .Include(x => x.Items)
                .ThenInclude(x => x.ItemCategory)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (menu == null)
        {
            return OperationResult<Menu>.Failed(new PersistenceException(Consts.ExceptionMessages.NOT_FOUND));
        }

        return OperationResult<Menu>.Success((Menu)menu);
    }

    public async Task<OperationResult<IEnumerable<Menu>>> GetMenus(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        var menus = await context.Menus
            .AsNoTracking()
            .Include(x => x.Items)
                .ThenInclude(x => x.Availability)
            .Include(x => x.Items)
                .ThenInclude(x => x.ItemCategory)
            .Where(x => ids.Contains(x.Id))
            .ToListAsync(cancellationToken);

        return OperationResult<IEnumerable<Menu>>.Success(
            menus.Select(x => new Menu()
            {
                Id = x.Id,
                Name = x.Name,
                RestaurantId = x.RestaurantId,
                Items = x.Items.Select(y => (MenuItem)y)
            }));
    }
}
