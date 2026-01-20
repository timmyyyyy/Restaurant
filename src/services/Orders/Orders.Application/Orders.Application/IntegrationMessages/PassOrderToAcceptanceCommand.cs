using Orders.Application.Dtos;

namespace Restaurant.IntegrationMessages;

public record PassOrderToAcceptanceCommand
{
    public PassOrderToAcceptanceCommand(OrderDto order)
    {
        Order = order;
    }

    public OrderDto Order { get; private set; }
}
