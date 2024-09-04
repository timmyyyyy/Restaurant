using MassTransit;
using Restaurant.Common.FlowBuildingBlocks;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Common.DomainBuildingBlocks
{
    public static class DomainEventDispatcher
    {
        public static async Task DispatchDomainEvents(this MediatR.IMediator mediator, AggregateRoot aggregateRoot, CancellationToken cancellationToken)
        {
            var eventsOfInterests = aggregateRoot.DomainEvents.Where(x => x is not IStronglyTypedNotification).ToArray();
            foreach (var e in eventsOfInterests)
            {
                await mediator.Publish(e, cancellationToken);
            }
        }

        public static async Task DispatchDomainEvents(this IPublishEndpoint publishEndpoint, AggregateRoot aggregateRoot, CancellationToken cancellationToken)
        {
            var eventsOfInterests = aggregateRoot.DomainEvents
                .Where(x => x is IStronglyTypedNotification)
                .Cast<IStronglyTypedNotification>()
                .ToArray();

            foreach (var e in eventsOfInterests)
            {
                await publishEndpoint.Publish(e, e.Type, cancellationToken);
            }
        }
    }
}
