namespace Orders.API.Application.IntegrationEvents
{
    public class OrderSavedAsDraftIntegrationEvent
    {
        public OrderSavedAsDraftIntegrationEvent(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; private set; }
    }
}
