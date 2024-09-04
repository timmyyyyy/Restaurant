using MassTransit;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Orders.API.Infrastructure.Configuration;

namespace Orders.API.Infrastructure
{
    public class OrdersDbContext : SagaDbContext
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public OrdersDbContext(DbContextOptions options, IPublishEndpoint publishEndpoint) : base(options)
        {
            _publishEndpoint = publishEndpoint;
        }

        protected override IEnumerable<ISagaClassMap> Configurations => new[] { new OrderStateInstanceMapConfiguration() };
    }
}
