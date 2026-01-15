using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Commands;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDraftCommand command)
        {
            var response = await mediator.Send(command);

            // TODO

            return Ok(response);
        }
    }
}
