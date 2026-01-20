using Orders.Application.Dtos;

namespace Restaurant.IntegrationMessages;

public record OrderReceivedIntegrationEvent
{
    public OrderReceivedIntegrationEvent(OrderDto order)
    {
        Order = order;
    }

    public OrderDto Order { get; private set; }
}
