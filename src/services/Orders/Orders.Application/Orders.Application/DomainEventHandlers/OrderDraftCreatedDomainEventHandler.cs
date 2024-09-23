using MassTransit;
using MediatR;
using Orders.Application.Dtos;
using Restaurant.IntegrationMessages;
using Orders.Domain.Aggregates.Order;
using Orders.Domain.Aggregates.Order.DomainEvents;
using Orders.Infrastructure;

namespace Orders.Application.DomainEventHandlers
{
    public class OrderDraftCreatedDomainEventHandler : INotificationHandler<OrderDraftCreatedDomainEvent>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        private readonly IOrderRepository _orderRepository;

        private readonly OrdersDbContext _ordersDbContext;

        public OrderDraftCreatedDomainEventHandler(IPublishEndpoint publishEndpoint, IOrderRepository orderRepository,
            OrdersDbContext ordersDbContext)
        {
            _publishEndpoint = publishEndpoint;
            _orderRepository = orderRepository;
            _ordersDbContext = ordersDbContext;
        }

        public async Task Handle(OrderDraftCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            // TODO mapping
            var orderDto = (OrderDto)notification.Order;
            var orderReceivedIntegrationEvent = new OrderReceivedIntegrationEvent(orderDto);

            // TODO add mediatr behavior to wrap it in transaction, to make sure that no one will inovke it in other order
            await _publishEndpoint.Publish(orderReceivedIntegrationEvent, cancellationToken);
            await _ordersDbContext.SaveChangesAsync(cancellationToken);
            //await _orderRepository.AddOrder(notification.Order);
        }
    }
}
