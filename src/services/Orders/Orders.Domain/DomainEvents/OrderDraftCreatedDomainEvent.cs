using MediatR;

namespace Orders.Domain.DomainEvents
{
    public class OrderDraftCreatedDomainEvent : INotification
    {
        public OrderDraftCreatedDomainEvent(Guid orderId, Guid restaurantId, IEnumerable<Guid> menuItemsIds)
        {
            OrderId = orderId;
            RestaurantId = restaurantId;
            MenuItemsIds = menuItemsIds;
        }

        public Guid OrderId { get; set; }

        public Guid RestaurantId { get; private set; }

        public IEnumerable<Guid> MenuItemsIds { get; private set; }
    }
}
