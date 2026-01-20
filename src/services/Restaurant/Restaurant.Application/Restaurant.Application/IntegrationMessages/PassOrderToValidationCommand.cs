using Restaurant.Application.Dtos;

namespace Restaurant.IntegrationMessages;

public record PassOrderToValidationCommand
{
    public PassOrderToValidationCommand() { }

    public PassOrderToValidationCommand(OrderDto order)
    {
        Order = order;
    }

    public required OrderDto Order { get; init; }
}
