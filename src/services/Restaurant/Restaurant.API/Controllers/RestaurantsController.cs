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
        // TODO, for now we return always the same restaurant id
        var firstRestaurant = await _dbContext.Restaurants.FirstOrDefaultAsync();
        var restaurant = firstRestaurant?.Id ?? Guid.Empty;
        var result = new { restaurantId = restaurant };
        return Ok(result);
    }

    [HttpGet("{restaurantId}/menu")]
    public async Task<IActionResult> GetMenuByRestaurantId(Guid restaurantId, CancellationToken cancellationToken)
    {
        var menu = await _mediator.Send(new GetMenuByRestaurantIdQuery(restaurantId), cancellationToken);
        
        if (menu == null)
            return NotFound(new { message = "Menu not found for the specified restaurant" });
        
        return Ok(menu);
    }
}
