
namespace Restaurant.IntegrationMessages
{
    public record PaymentConfirmedIntegrationEvent : IBaseOrderMessage
    {
        public Guid OrderId { get; init; }
    }
}
