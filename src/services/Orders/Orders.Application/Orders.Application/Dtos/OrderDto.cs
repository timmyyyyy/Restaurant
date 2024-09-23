using MassTransit.Transports;
using Orders.Domain.Aggregates.Order;
using Orders.Infrastructure.Models;

namespace Orders.Application.Dtos
{
    public record OrderDto
    {
        public Guid Id { get; init; }

        public string? EmailAddress { get; init; }

        public string? PhoneNumber { get; init; }

        public Guid RestaurantId { get; init; }

        public Guid? CustomerId { get; init; }

        public AddressDto DeliveryAddress { get; init; }

        public List<Guid> MenuItemsIds { get; init; }

        public bool PaymentOnDelivery { get; init; }

        public static explicit operator OrderDto (Order order)
        {
            return new()
            {
                Id = order.Id,
                EmailAddress = order.EmailAddress,
                PhoneNumber = order.PhoneNumber,
                RestaurantId = order.RestaurantId,
                MenuItemsIds = order.MenuItemsIds,
                PaymentOnDelivery = order.PaymentOnDelivery,
                DeliveryAddress = (AddressDto)order.DeliveryAddress,
                CustomerId = order.CustomerId,
            };
        }

        public static explicit operator OrderDbEntity (OrderDto order)
        {
            return new()
            {
                CorrelationId = order.Id,
                EmailAddress = order.EmailAddress,
                PhoneNumber = order.PhoneNumber,
                RestaurantId = order.RestaurantId,
                MenuItemsIds = order.MenuItemsIds,
                PaymentOnDelivery = order.PaymentOnDelivery,
                DeliveryAddress = (AddressDbEntity)order.DeliveryAddress,
                CustomerId = order.CustomerId,
            };
        }

        public static explicit operator OrderDto(OrderDbEntity order)
        {
            return new()
            {
                Id = order.CorrelationId,
                EmailAddress = order.EmailAddress,
                PhoneNumber = order.PhoneNumber,
                RestaurantId = order.RestaurantId,
                MenuItemsIds = order.MenuItemsIds,
                PaymentOnDelivery = order.PaymentOnDelivery,
                DeliveryAddress = (AddressDto)order.DeliveryAddress,
                CustomerId = order.CustomerId,
            };
        }
    }
}
