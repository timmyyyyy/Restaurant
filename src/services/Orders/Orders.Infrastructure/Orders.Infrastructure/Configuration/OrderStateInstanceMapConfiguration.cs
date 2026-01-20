using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderSagaStateDbEntity = Orders.Infrastructure.Models.OrderSagaStateDbEntity;

namespace Orders.Infrastructure.Configuration;

public class OrderStateInstanceMapConfiguration : SagaClassMap<OrderSagaStateDbEntity>
{
    protected override void Configure(EntityTypeBuilder<OrderSagaStateDbEntity> entity, ModelBuilder model)
    {
        entity.ToTable("OrderSagaState");
        entity.HasKey(x => x.CorrelationId);
        entity.Property(x => x.CorrelationId).ValueGeneratedNever();

        entity.Property(x => x.CurrentState);
        entity.Property(x => x.PaymentOnDelivery);
        
        entity.Property(x => x.RowVersion).IsRowVersion();
    }
}
