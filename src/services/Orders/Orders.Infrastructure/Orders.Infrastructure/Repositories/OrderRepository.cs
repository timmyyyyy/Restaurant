using System.Threading;
using Orders.Domain.Aggregates.Order;
using Orders.Infrastructure.Models;
using Restaurant.Common.InfrastructureBuildingBlocks.DI;

namespace Orders.Infrastructure.Repositories;

public class OrderRepository(OrdersDbContext context) : IOrderRepository, IScopedDependency
{
    public async Task AddOrder(Order order, CancellationToken cancellationToken = default)
    {
        var orderDbEntity = (OrderDbEntity)order;

        await context.AddAsync(orderDbEntity, cancellationToken);
    }
}
