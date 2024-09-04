namespace Orders.Application.IntegrationEvents
{
    public class OrderReceivedIntegrationEvent
    {
        public OrderReceivedIntegrationEvent(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; private set; }
    }
}
