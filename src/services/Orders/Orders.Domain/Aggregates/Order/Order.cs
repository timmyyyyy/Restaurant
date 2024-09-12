using MassTransit;
using Orders.Domain.Aggregates.Order.DomainEvents;
using Restaurant.Common.DomainBuildingBlocks;
using Restaurant.Common.FlowBuildingBlocks;

namespace Orders.Domain.Aggregates.Order
{
    public class Order : AggregateRoot
    {
        public OrderStatus Status { get; private set; }

        public string? EmailAddress { get; private set; }

        public string? PhoneNumber { get; private set; }

        public Guid? CustomerId { get; private set; }

        public Guid RestaurantId { get; private set; }

        public Address DeliveryAddress { get; private set; }

        public List<Guid> MenuItemsIds { get; private set; }

        public bool PaymentOnDelivery { get; set; }

        internal Order()
        {
            Id = NewId.NextGuid();
            Status = OrderStatus.Draft;
        }

        public static OperationResult<Order> CreateOrder(string? emailAddress, string? phoneNumber, Guid? customerId,
            Guid restaurantId, Address deliveryAddress, List<Guid> menuItemsIds, bool paymentOnDelivery)
        {
            if ((string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(phoneNumber)) && customerId == null)
            {
                // TODO
                var ex = new Exception();
                return new OperationResult<Order>(ex);
            }

            if ((!string.IsNullOrEmpty(emailAddress) || !string.IsNullOrEmpty(phoneNumber) && customerId != null))
            {
                // TODO
                var ex = new Exception();
                return new OperationResult<Order>(ex);
            }

            var order = new Order()
            {
                EmailAddress = emailAddress,
                PhoneNumber = phoneNumber,
                CustomerId = customerId,
                DeliveryAddress = deliveryAddress,
                MenuItemsIds = menuItemsIds,
                RestaurantId = restaurantId,
                PaymentOnDelivery = paymentOnDelivery
            };

            order.AddDomainEvent(new OrderDraftCreatedDomainEvent(order));

            return new OperationResult<Order>(order);
        }
    }
}
