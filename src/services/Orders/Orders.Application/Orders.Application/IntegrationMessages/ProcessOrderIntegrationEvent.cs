using Orders.Application.Dtos;

namespace Orders.Application.IntegrationMessages
{
    public record ProcessOrderIntegrationEvent
    {
        public ProcessOrderIntegrationEvent(OrderDto order)
        {
            Order = order;
        }

        public OrderDto Order { get; init; }
    }
}
