using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Commands;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDraftCommand command)
        {
            var response = await _mediator.Send(command);

            // TODO

            return Ok(response);
        }
    }
}
