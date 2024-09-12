using Orders.Application.Dtos;

namespace Orders.Application.IntegrationMessages
{
    public record OrderReceivedIntegrationEvent
    {
        public OrderReceivedIntegrationEvent(OrderDto order)
        {
            Order = order;
        }

        public OrderDto Order { get; private set; }
    }
}
