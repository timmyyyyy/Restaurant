using MediatR;
using Restaurant.Common.FlowBuildingBlocks;
using System.Text.Json.Serialization;

namespace Orders.Domain.DomainEvents
{
    public class OrderDraftCreatedDomainEvent : IStronglyTypedNotification
    {
        public OrderDraftCreatedDomainEvent(Guid orderId, Guid restaurantId, List<Guid> menuItemsIds)
        {
            OrderId = orderId;
            RestaurantId = restaurantId;
            MenuItemsIds = menuItemsIds;
        }

        [JsonIgnore]
        public Type Type => typeof(OrderDraftCreatedDomainEvent);

        public Guid OrderId { get; set; }

        public Guid RestaurantId { get; private set; }

        public List<Guid> MenuItemsIds { get; private set; }
    }
}
