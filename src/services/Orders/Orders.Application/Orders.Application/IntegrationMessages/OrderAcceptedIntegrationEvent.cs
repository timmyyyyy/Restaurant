
namespace Restaurant.IntegrationMessages;

public record OrderAcceptedIntegrationEvent : IBaseOrderMessage
{
    public Guid OrderId { get; init; }
}
