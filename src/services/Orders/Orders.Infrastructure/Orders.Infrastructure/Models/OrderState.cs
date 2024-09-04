using MassTransit;

namespace Orders.Infrastructure.Models
{
    public class OrderState : SagaStateMachineInstance
    {
        // TODO optimistic concurrency field with version

        // TODO CorrelationId should be primary key with clustered index
        public Guid CorrelationId { get; set; }

        public string CurrentState { get; set; }
    }
}
