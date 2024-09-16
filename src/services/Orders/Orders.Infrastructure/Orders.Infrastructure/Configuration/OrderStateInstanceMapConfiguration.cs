using MassTransit;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderDbEntity = Orders.Infrastructure.Models.OrderDbEntity;

namespace Orders.Infrastructure.Configuration
{
    public class OrderStateInstanceMapConfiguration : SagaClassMap<OrderDbEntity>
    {
        protected override void Configure(EntityTypeBuilder<OrderDbEntity> entity, ModelBuilder model)
        {
            entity.HasKey(x => x.CorrelationId);
            entity.Property(x => x.CorrelationId).ValueGeneratedNever();

            entity.Property(x => x.CurrentState);
            entity.Property(x => x.EmailAddress);
            entity.Property(x => x.RestaurantId);
            entity.Property(x => x.CustomerId);
            entity.Property(x => x.PaymentOnDelivery);
            entity.Property(x => x.PhoneNumber);
            entity.Property(x => x.MenuItemsIds).HasJsonConversion();
            entity.HasOne(x => x.DeliveryAddress).WithMany(x => x.Orders).HasForeignKey(x => x.CorrelationId);
        }
    }
}
