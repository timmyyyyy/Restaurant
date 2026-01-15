using MassTransit;
using Microsoft.IdentityModel.Tokens;
using Orders.Domain.Aggregates.Order.DomainEvents;
using Orders.Domain.Aggregates.Order.Parameters;
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

        public static OperationResult<Order> CreateOrder(OrderCreationParams input)
        {
            if ((string.IsNullOrEmpty(input.EmailAddress) || string.IsNullOrEmpty(input.PhoneNumber)) && input.CustomerId == null)
            {
                // TODO
                var ex = new Exception();
                return new OperationResult<Order>(ex);
            }

            if ((!string.IsNullOrEmpty(input.EmailAddress) || !string.IsNullOrEmpty(input.PhoneNumber)) && input.CustomerId != null)
            {
                // TODO
                var ex = new Exception();
                return new OperationResult<Order>(ex);
            }

            var addressResult = Address.CreateAddress(input.AddressCreationParams);

            if (!addressResult.IsSuccess)
            {
                // TODO
                var ex = new Exception();
                return new OperationResult<Order>(ex);
            }

            var order = new Order()
            {
                EmailAddress = input.EmailAddress,
                PhoneNumber = input.PhoneNumber,
                CustomerId = input.CustomerId,
                MenuItemsIds = input.MenuItemsIds,
                RestaurantId = input.RestaurantId,
                PaymentOnDelivery = input.PaymentOnDelivery,
                DeliveryAddress = addressResult.Value
            };

            order.AddDomainEvent(new OrderDraftCreatedDomainEvent(order));

            return new OperationResult<Order>(order);
        }
    }
}
