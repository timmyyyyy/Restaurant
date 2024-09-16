namespace Payments.API.Application.IntegrationEvents
{
    public record PaymentConfirmedIntegrationEvent
    {
        public Guid OrderId { get; init; }
    }
}
