namespace Orders.Application.IntegrationMessages
{
    public record OrderValidatedSuccessfullyIntegrationEvent
    {
        public Guid OrderId { get; private set; }
    }
}
