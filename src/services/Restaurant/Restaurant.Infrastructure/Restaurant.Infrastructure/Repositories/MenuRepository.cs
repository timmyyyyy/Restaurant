using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry;
using Restaurant.Common;
using Restaurant.Common.FlowBuildingBlocks;
using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;
using Restaurant.Domain.Aggregates.Menu;

namespace Restaurant.Infrastructure.Repositories
{
    // TODO cancellation tokens
    public class MenuRepository : IMenuRepository
    {
        private readonly RestaurantDbContext _context;

        public MenuRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult<Menu>> GetMenu(Guid id)
        {
            var menu = await _context.Menus
                .AsNoTracking()
                .Include(x => x.Items)
                    .ThenInclude(x => x.Availability)
                .Include(x => x.Items)
                    .ThenInclude(x => x.ItemCategory)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (menu == null)
                return new OperationResult<Menu>(new PersistenceException(Consts.ExceptionMessages.NOT_FOUND));

            return new OperationResult<Menu>((Menu)menu);
        }

        public async Task<OperationResult<IEnumerable<Menu>>> GetMenus(IEnumerable<Guid> ids)
        {
            var menus = await _context.Menus
                .AsNoTracking()
                .Include(x => x.Items)
                    .ThenInclude(x => x.Availability)
                .Include(x => x.Items)
                    .ThenInclude(x => x.ItemCategory)
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            return new OperationResult<IEnumerable<Menu>>(
                menus.Select(x => new Menu()
                {
                    Id = x.Id,
                    Name = x.Name,
                    RestaurantId = x.RestaurantId,
                    Items = x.Items.Select(y => (MenuItem)y)
                }));
        }
    }
}
