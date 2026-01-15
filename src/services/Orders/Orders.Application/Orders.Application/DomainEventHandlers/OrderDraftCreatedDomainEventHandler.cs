using MediatR;
using Orders.Domain.Aggregates.Order;
using Orders.Domain.Aggregates.Order.DomainEvents;

namespace Orders.Application.DomainEventHandlers
{
    public class OrderDraftCreatedDomainEventHandler(IOrderRepository orderRepository) : INotificationHandler<OrderDraftCreatedDomainEvent>
    {
        public Task Handle(OrderDraftCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            return orderRepository.AddOrder(notification.Order);
        }
    }
}
