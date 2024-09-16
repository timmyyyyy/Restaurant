using MassTransit;

namespace Orders.Infrastructure.Models
{
    public class OrderDbEntity : SagaStateMachineInstance
    {
        // TODO optimistic concurrency field with version

        // TODO CorrelationId should be primary key with clustered index
        public Guid CorrelationId { get; set; }

        public string CurrentState { get; set; }

        public string? EmailAddress { get; set; }

        public string? PhoneNumber { get; set; }

        public Guid? CustomerId { get; set; }

        public Guid RestaurantId { get; set; }

        public AddressDbEntity DeliveryAddress { get; set; }

        public List<Guid> MenuItemsIds { get; set; }

        public bool PaymentOnDelivery { get; set; }
    }
}
