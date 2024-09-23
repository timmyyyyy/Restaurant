namespace Restaurant.IntegrationMessages
{
    public record PaymentConfirmedIntegrationEvent
    {
        public Guid OrderId { get; init; }
    }
}
