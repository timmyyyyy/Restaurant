
namespace Orders.Application.IntegrationMessages
{
    public record PaymentRefundedIntegrationEvent : IBaseOrderMessage
    {
        public Guid OrderId { get; init; }
    }
}
