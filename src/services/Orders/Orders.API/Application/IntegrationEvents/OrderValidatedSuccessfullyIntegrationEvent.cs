namespace Orders.API.Application.IntegrationEvents
{
    public class OrderValidatedSuccessfullyIntegrationEvent
    {
        public Guid OrderId { get; private set; }
    }
}
