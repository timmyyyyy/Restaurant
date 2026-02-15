using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Queries;
using Restaurant.Infrastructure;

namespace Restaurant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{
    private readonly RestaurantDbContext _dbContext;
    private readonly IMediator _mediator;

    public RestaurantsController(RestaurantDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
    }

    [HttpGet("nearest")]
    public async Task<IActionResult> GetNearestRestaurant(string customerAddress)
    {
        var queryResult = await _mediator.Send(new GetNearestRestaurantQuery(customerAddress));

        var result = new { restaurantId = queryResult.Value };
        return Ok(result);
    }

    [HttpGet("{restaurantId}/menu")]
    public async Task<IActionResult> GetMenuByRestaurantId(Guid restaurantId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetMenuByRestaurantIdQuery(restaurantId), cancellationToken);

        return Ok(result.Value);
    }
}
