using MassTransit;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Orders.Infrastructure.Configuration;
using Orders.Infrastructure.Models;
using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;

namespace Orders.Infrastructure
{
    public class OrdersDbContext : BaseDbContext
    {
        public OrdersDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<OrderDbEntity> Orders { get; set; }

        public DbSet<AddressDbEntity> Adresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();
        }

        protected override IEnumerable<ISagaClassMap> Configurations => new[] { new OrderStateInstanceMapConfiguration() };
    }
}
