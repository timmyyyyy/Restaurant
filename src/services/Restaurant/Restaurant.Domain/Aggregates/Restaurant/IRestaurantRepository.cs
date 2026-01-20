using System;
using System.Threading;
using System.Threading.Tasks;
using Restaurant.Common.InfrastructureBuildingBlocks.DI;

namespace Restaurant.Domain.Aggregates.Restaurant;

public interface IRestaurantRepository : IScopedDependency
{
    Task<Restaurant> GetRestaurant(Guid id, CancellationToken cancellationToken = default);
}
