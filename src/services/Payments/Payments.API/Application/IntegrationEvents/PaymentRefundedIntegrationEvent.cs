namespace Payments.API.Application.IntegrationEvents
{
    public record PaymentRefundedIntegrationEvent
    {
        public Guid OrderId { get; init; }
    }
}
