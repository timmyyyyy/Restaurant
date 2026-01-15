using MediatR;
using Restaurant.Common.InfrastructureBuildingBlocks.DI;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Common.ApplicationBuildingBlocks
{
    public interface IDomainEventCollector : IScopedDependency
    {
        void Add(IEnumerable<INotification> domainEvents);

        Task Dispatch();
    }

    public sealed class DomainEventCollector : IDomainEventCollector
    {
        private readonly List<INotification> _domainEvents;

        private readonly IMediator _mediator;

        public DomainEventCollector(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Add(IEnumerable<INotification> domainEvents)
        {
            _domainEvents.AddRange(domainEvents);
        }

        public async Task Dispatch()
        {
            foreach (var domainEvent in _domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }

            _domainEvents.Clear();
        }
    }
}
