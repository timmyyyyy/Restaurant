using MassTransit;
using Orders.API.Application.Dtos;

namespace Orders.Domain.StateMachines
{
    public class OrderState : SagaStateMachineInstance
    {
        // TODO optimistic concurrency field with version

        // TODO CorrelationId should be primary key with clustered index
        public Guid CorrelationId { get; set; }

        public string CurrentState { get; set; }
    }
}
