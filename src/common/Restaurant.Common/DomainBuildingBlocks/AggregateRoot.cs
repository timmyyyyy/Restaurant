using MassTransit;
using MediatR;
using System.Collections.Generic;

namespace Restaurant.Common.DomainBuildingBlocks
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot()
        {
            Id = NewId.NextSequentialGuid();
        }

        private List<INotification> _domainEvents = new List<INotification>();

        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(INotification domainEvent) => _domainEvents.Add(domainEvent);

        public void RemoveDomainEvent(INotification domainEvent) => _domainEvents.Remove(domainEvent);

        public void ClearEvents() => _domainEvents.Clear();
    }
}
