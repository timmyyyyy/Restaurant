using Restaurant.Common.InfrastructureBuildingBlocks.DI;
using System;
using System.Threading.Tasks;

namespace Restaurant.Domain.Aggregates.Restaurant
{
    public interface IRestaurantRepository : IScopedDependency
    {
        Task<Restaurant> GetRestaurant(Guid id);
    }
}
