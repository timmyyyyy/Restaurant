namespace Restaurant.Application.IntegrationMessages
{
    public record OrderAcceptedIntegrationEvent
    {
        public Guid OrderId { get; init; }
    }
}
