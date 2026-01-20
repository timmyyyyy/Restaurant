using Orders.Domain.Aggregates.Order;
using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;

namespace Orders.Infrastructure.Models;

public class OrderDbEntity : BaseDbEntity
{
    internal OrderDbEntity() { }

    public OrderStatus Status { get; set; }

    public string? EmailAddress { get; set; }

    public string? PhoneNumber { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid RestaurantId { get; set; }

    public required AddressDbEntity DeliveryAddress { get; set; }

    public required List<Guid> MenuItemsIds { get; set; }

    public bool PaymentOnDelivery { get; set; }

    public static implicit operator OrderDbEntity(Order order) =>
        new()
        {
            Id = order.Id,
            Status = order.Status,
            EmailAddress = order.EmailAddress,
            PhoneNumber = order.PhoneNumber,
            CustomerId = order.CustomerId,
            RestaurantId = order.RestaurantId,
            DeliveryAddress = (AddressDbEntity)order.DeliveryAddress,
            MenuItemsIds = order.MenuItemsIds,
            PaymentOnDelivery = order.PaymentOnDelivery,
        };
}
