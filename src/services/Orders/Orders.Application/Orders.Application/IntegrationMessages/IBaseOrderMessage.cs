using MassTransit;

namespace Orders.Application.IntegrationMessages
{
    [ExcludeFromTopology]
    public interface IBaseOrderMessage
    {
        Guid OrderId { get; }
    }
}
