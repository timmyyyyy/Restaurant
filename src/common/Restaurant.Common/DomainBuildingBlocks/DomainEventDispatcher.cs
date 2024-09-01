using MassTransit;
using Restaurant.Common.FlowBuildingBlocks;
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
                if (e is IStronglyTypedNotification ste)
                    await publishEndpoint.Publish(e, ste.Type);
                else
                    continue;
            }
        }
    }
}
