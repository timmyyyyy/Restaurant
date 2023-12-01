using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orders.API.Application.Commands;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderDraftCommand command)
        {
            var response = _mediator.Send(command);

            // TODO

            return Ok(response);
        }
    }
}
