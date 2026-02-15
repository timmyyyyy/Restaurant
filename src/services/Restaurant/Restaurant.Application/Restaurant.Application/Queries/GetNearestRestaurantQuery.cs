using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Common.ApplicationBuildingBlocks;
using Restaurant.Infrastructure;

namespace Restaurant.Application.Queries;

public record GetNearestRestaurantQuery(string Address) : IRequest<OperationResult<Guid>>;


public class GetNearestRestaurantQueryHandler : IRequestHandler<GetNearestRestaurantQuery, OperationResult<Guid>>
{
    private readonly RestaurantDbContext _dbContext;

    public GetNearestRestaurantQueryHandler(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OperationResult<Guid>> Handle(GetNearestRestaurantQuery request, CancellationToken cancellationToken)
    {
        // TODO, for now we return always the same restaurant id
        var firstRestaurant = await _dbContext.Restaurants.FirstOrDefaultAsync();
        var restaurant = firstRestaurant?.Id ?? Guid.Empty;

        return OperationResult<Guid>.Success(restaurant);
    }
}
