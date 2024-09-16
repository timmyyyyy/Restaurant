namespace Restaurant.Application.IntegrationMessages
{
    public record OrderDeclinedIntegrationEvent
    {
        public Guid OrderId { get; init; }

        public string Reason { get; init; }
    }
}
