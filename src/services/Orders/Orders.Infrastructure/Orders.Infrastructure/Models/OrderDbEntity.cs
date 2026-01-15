using Orders.Domain.Aggregates.Order;
using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Models
{
    public class OrderDbEntity : BaseDbEntity
    {
        public OrderStatus Status { get; set; }

        public string? EmailAddress { get; set; }

        public string? PhoneNumber { get; set; }

        public Guid? CustomerId { get; set; }

        public Guid RestaurantId { get; set; }

        public AddressDbEntity DeliveryAddress { get; set; }

        public List<Guid> MenuItemsIds { get; set; }

        public bool PaymentOnDelivery { get; set; }

        public static implicit operator OrderDbEntity(Order order) =>
            new OrderDbEntity()
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
}
