using MassTransit;
using Orders.Domain.Aggregates.Order;
using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;

namespace Orders.Infrastructure.Models
{
    public class OrderDbEntity : BaseDbEntity, SagaStateMachineInstance
    {
        // TODO optimistic concurrency field with version
        public Guid CorrelationId { get; set; }

        public string CurrentState { get; set; }

        public string? EmailAddress { get; set; }

        public string? PhoneNumber { get; set; }

        public Guid? CustomerId { get; set; }

        public Guid RestaurantId { get; set; }

        public AddressDbEntity DeliveryAddress { get; set; }

        public List<Guid> MenuItemsIds { get; set; }

        public bool PaymentOnDelivery { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        //public static explicit operator OrderDbEntity(Order order) 
        //    => new OrderDbEntity()
        //    {
        //        Id = order.Id,
        //        EmailAddress = order.EmailAddress,
        //        DeliveryAddress = (AddressDbEntity)order.DeliveryAddress,
        //        PaymentOnDelivery = order.PaymentOnDelivery,
        //        d
        //    }
    }
}
