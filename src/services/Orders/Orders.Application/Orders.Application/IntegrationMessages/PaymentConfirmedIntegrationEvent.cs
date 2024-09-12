
namespace Orders.Application.IntegrationMessages
{
    public record PaymentConfirmedIntegrationEvent : IBaseOrderMessage
    {
        public Guid OrderId { get; init; }
    }
}
