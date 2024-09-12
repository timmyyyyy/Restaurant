using MassTransit;

namespace Orders.Infrastructure.Models
{
    public class Order : SagaStateMachineInstance
    {
        // TODO optimistic concurrency field with version

        // TODO CorrelationId should be primary key with clustered index
        public Guid CorrelationId { get; set; }

        public string CurrentState { get; set; }

        public string? EmailAddress { get; private set; }

        public string? PhoneNumber { get; private set; }

        public Guid? CustomerId { get; private set; }

        public Guid RestaurantId { get; private set; }

        public Address DeliveryAddress { get; private set; }

        public List<Guid> MenuItemsIds { get; private set; }

        public bool PaymentOnDelivery { get; set; }
    }
}
