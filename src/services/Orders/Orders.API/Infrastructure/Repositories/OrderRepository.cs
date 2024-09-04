using Orders.Domain.Aggregates.Order;
using Restaurant.Common.InfrastructureBuildingBlocks;
using Restaurant.Common.InfrastructureBuildingBlocks.DI;
using Restaurant.Common.InfrastructureBuildingBlocks.Repos;

namespace Orders.API.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository, IScopedDependency, IRepository
    {
        private readonly OrdersDbContext _context;

        public OrderRepository(OrdersDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Task AddOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
