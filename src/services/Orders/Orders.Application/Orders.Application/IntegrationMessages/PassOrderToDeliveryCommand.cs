using Orders.Application.Dtos;

namespace Restaurant.IntegrationMessages;

public record PassOrderToDeliveryCommand
{
    public PassOrderToDeliveryCommand(OrderDto order)
    {
        Order = order;
    }

    public OrderDto Order { get; private set; }
}
