using MassTransit;
using Orders.Domain.Aggregates.Order.DomainEvents;
using Orders.Domain.Aggregates.Order.Parameters;
using Restaurant.Common.ApplicationBuildingBlocks;
using Restaurant.Common.DomainBuildingBlocks;

namespace Orders.Domain.Aggregates.Order;

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

    public required Address DeliveryAddress { get; init; }

    public required List<Guid> MenuItemsIds { get; init; }

    public bool PaymentOnDelivery { get; init; }

    public static OperationResult<Order> CreateOrder(OrderCreationParams input)
    {
        if (string.IsNullOrWhiteSpace(input.EmailAddress) && 
            string.IsNullOrWhiteSpace(input.PhoneNumber) && 
            input.CustomerId is null)
        {
            return OperationResult<Order>.Failed(new ArgumentException("Either email/phone or customer ID must be provided"));
        }

        if ((!string.IsNullOrWhiteSpace(input.EmailAddress) || !string.IsNullOrWhiteSpace(input.PhoneNumber)) && 
            input.CustomerId is not null)
        {
            return OperationResult<Order>.Failed(new ArgumentException("Cannot provide both contact details and customer ID"));
        }

        var addressResult = Address.CreateAddress(input.AddressCreationParams);

        if (!addressResult.IsSuccess)
        {
            return OperationResult<Order>.Failed(new InvalidOperationException("Invalid address"));
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

        return OperationResult<Order>.Success(order);
    }
}
