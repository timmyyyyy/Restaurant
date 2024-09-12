using MassTransit;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Order = Orders.Infrastructure.Models.Order;

namespace Orders.Infrastructure.Configuration
{
    public class OrderStateInstanceMapConfiguration : SagaClassMap<Order>
    {
        protected override void Configure(EntityTypeBuilder<Order> entity, ModelBuilder model)
        {
            entity.HasKey(x => x.CorrelationId).IsClustered();

            entity.Property(x => x.CorrelationId);
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
