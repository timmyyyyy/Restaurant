using MassTransit;
using System.Threading.Tasks;

namespace Restaurant.Common.DomainBuildingBlocks
{
    public static class DomainEventDispatcher
    {
        public static async Task DispatchDomainEvents(this MediatR.IMediator mediator, AggregateRoot aggregateRoot)
        {
            foreach (var e in aggregateRoot.DomainEvents)
            {
                await mediator.Publish(e);
            }
        }

        public static async Task DispatchDomainEvents(this IPublishEndpoint publishEndpoint, AggregateRoot aggregateRoot)
        {
            foreach (var e in aggregateRoot.DomainEvents)
            {
                await publishEndpoint.Publish(e);
            }
        }
    }
}
