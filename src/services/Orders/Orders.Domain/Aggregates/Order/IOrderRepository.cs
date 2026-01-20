using System.Threading;
using Restaurant.Common.InfrastructureBuildingBlocks.DI;

namespace Orders.Domain.Aggregates.Order;

public interface IOrderRepository : IScopedDependency
{
    Task AddOrder(Order order, CancellationToken cancellationToken = default);
}
