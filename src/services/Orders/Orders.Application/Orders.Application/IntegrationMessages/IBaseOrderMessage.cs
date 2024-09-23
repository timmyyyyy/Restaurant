using MassTransit;

namespace Restaurant.IntegrationMessages
{
    [ExcludeFromTopology]
    public interface IBaseOrderMessage
    {
        Guid OrderId { get; }
    }
}
