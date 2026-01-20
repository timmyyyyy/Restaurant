
namespace Restaurant.IntegrationMessages;

public record OrderReadyIntegrationEvent : IBaseOrderMessage
{
    public Guid OrderId { get; init; }
}
