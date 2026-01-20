using System;
using System.Collections.Generic;
using MassTransit;
using MediatR;

namespace Restaurant.Common.DomainBuildingBlocks;

public abstract class AggregateRoot : Entity
{
    protected AggregateRoot()
    {
        Id = NewId.NextSequentialGuid();
    }

    private readonly List<INotification> _domainEvents = [];

    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(INotification domainEvent) => _domainEvents.Add(domainEvent);

    public void RemoveDomainEvent(INotification domainEvent) => _domainEvents.Remove(domainEvent);

    public void ClearEvents() => _domainEvents.Clear();
}
