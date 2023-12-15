using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Orders.API.Infrastructure.Configuration;
using System.Runtime.CompilerServices;

namespace Orders.API.Infrastructure
{
    public class OrdersDbContext : SagaDbContext
    {
        public OrdersDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override IEnumerable<ISagaClassMap> Configurations => new[] { new OrderStateInstanceMapConfiguration() };
    }
}
