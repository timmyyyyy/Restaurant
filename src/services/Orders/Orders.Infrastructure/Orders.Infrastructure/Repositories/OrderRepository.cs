using Orders.Domain.Aggregates.Order;
using Orders.Infrastructure.Models;
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

        public async Task AddOrder(Order order)
        {
            var orderDbEntity = (OrderDbEntity)order;

            await _context.AddAsync(orderDbEntity);
        }
    }
}
