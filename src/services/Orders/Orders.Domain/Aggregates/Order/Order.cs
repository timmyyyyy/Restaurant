using MassTransit;
using Orders.Domain.Aggregates.Order.DomainEvents;
using Restaurant.Common.DomainBuildingBlocks;
using Restaurant.Common.FlowBuildingBlocks;

namespace Orders.Domain.Aggregates.Order
{
    public sealed class Order : AggregateRoot
    {
        internal Order()
        {
            Id = NewId.NextSequentialGuid();
            Status = OrderStatus.Draft;
        }

        public OrderStatus Status { get; init; }

        public string? EmailAddress { get; init; }

        public string? PhoneNumber { get; init; }

        public Guid? CustomerId { get; init; }

        public Guid RestaurantId { get; init; }

        public Address DeliveryAddress { get; init; }

        public List<Guid> MenuItemsIds { get; init; }

        public bool PaymentOnDelivery { get; init; }

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
