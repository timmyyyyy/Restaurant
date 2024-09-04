using Orders.Domain.Aggregates.Order;
using Restaurant.Common.InfrastructureBuildingBlocks.DI;

namespace Orders.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository, IScopedDependency
    {
        private readonly OrdersDbContext _context;

        public OrderRepository(OrdersDbContext context)
        {
            _context = context;
        }

        public Task AddOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
