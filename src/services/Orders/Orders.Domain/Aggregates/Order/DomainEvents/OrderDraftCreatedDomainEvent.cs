using MediatR;

namespace Orders.Domain.Aggregates.Order.DomainEvents
{
    public class OrderDraftCreatedDomainEvent : INotification
    {
        public OrderDraftCreatedDomainEvent(Order order)
        {
            Order = order;
        }

        public Order Order { get; private set; }
    }
}
