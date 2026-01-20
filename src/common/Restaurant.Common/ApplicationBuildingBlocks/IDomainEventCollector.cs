using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Restaurant.Common.InfrastructureBuildingBlocks.DI;

namespace Restaurant.Common.ApplicationBuildingBlocks;

public interface IDomainEventCollector : IScopedDependency
{
    void Add(IEnumerable<INotification> domainEvents);

    Task Dispatch(CancellationToken cancellationToken = default);
}

public sealed class DomainEventCollector(IMediator mediator) : IDomainEventCollector
{
    private readonly List<INotification> _domainEvents = [];

    public void Add(IEnumerable<INotification> domainEvents)
    {
        _domainEvents.AddRange(domainEvents);
    }

    public async Task Dispatch(CancellationToken cancellationToken = default)
    {
        foreach (var domainEvent in _domainEvents)
        {
            await mediator.Publish(domainEvent, cancellationToken);
        }

        _domainEvents.Clear();
    }
}
