namespace Restaurant.Application.IntegrationMessages
{
    public record OrderReadyIntegrationEvent
    {
        public Guid OrderId { get; init; }
    }
}
