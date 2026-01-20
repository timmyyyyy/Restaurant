using System.Threading;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Commands;

namespace Orders.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderDraftCommand command, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(command, cancellationToken);

        // TODO

        return Ok(response);
    }
}
