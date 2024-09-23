namespace Restaurant.IntegrationMessages
{
    public record OrderAcceptedIntegrationEvent
    {
        public Guid OrderId { get; init; }
    }
}
