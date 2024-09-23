
namespace Restaurant.IntegrationMessages
{
    public record OrderNotDeliveredIntegrationEvent : IBaseOrderMessage
    {
        public Guid OrderId { get; init; }

        public string Reason { get; init; }
    }
}
