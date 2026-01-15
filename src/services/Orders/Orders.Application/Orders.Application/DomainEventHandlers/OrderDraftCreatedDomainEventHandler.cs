using MediatR;
using Orders.Domain.Aggregates.Order;
using Orders.Domain.Aggregates.Order.DomainEvents;

namespace Orders.Application.DomainEventHandlers
{
    public class OrderDraftCreatedDomainEventHandler : INotificationHandler<OrderDraftCreatedDomainEvent>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderDraftCreatedDomainEventHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task Handle(OrderDraftCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            return _orderRepository.AddOrder(notification.Order);
        }
    }
}
