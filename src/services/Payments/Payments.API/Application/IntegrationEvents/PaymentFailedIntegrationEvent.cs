namespace Payments.API.Application.IntegrationEvents
{
    public record PaymentFailedIntegrationEvent
    {
        public Guid OrderId { get; init; }
    }
}
