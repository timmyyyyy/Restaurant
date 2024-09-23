
namespace Restaurant.IntegrationMessages
{
    public record OrderCancelledIntegrationEvent : IBaseOrderMessage
    {
        public Guid OrderId { get; init; }
    }
}
