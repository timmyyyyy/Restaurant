using MassTransit;
using Orders.Domain.Aggregates.Order;
using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;

namespace Orders.Infrastructure.Models
{
    public class OrderSagaStateDbEntity : IDbEntityAuditable, SagaStateMachineInstance
    {
        // TODO optimistic concurrency field with version
        public Guid CorrelationId { get; set; }

        public string CurrentState { get; set; }

        public bool PaymentOnDelivery { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
