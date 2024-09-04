using MassTransit;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Orders.API.Infrastructure.Configuration;
using Restaurant.Common.DomainBuildingBlocks;
using Restaurant.Common.InfrastructureBuildingBlocks.Repos;

namespace Orders.API.Infrastructure
{
    public class OrdersDbContext : SagaDbContext, IUnitOfWork
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public OrdersDbContext(DbContextOptions options, IPublishEndpoint publishEndpoint) : base(options)
        {
            _publishEndpoint = publishEndpoint;
        }

        protected override IEnumerable<ISagaClassMap> Configurations => new[] { new OrderStateInstanceMapConfiguration() };

        // currently we are overriding these methods and make them unusable, to avoid situation when someone by mistake will call them,
        // instead of calling our custom UnitOfWork saving method (which will also publish events).
        // someone might call SaveChanges and then manually invoke DispatchDomainEvents and again SaveChanges, in this case
        // saving the entities and saving stuff to the outbox storage will not happen in the single transaction
        // if we would need in some case save some data without publishing events we would create decorator for dbContext or implement
        // another method which will allow it
        public override int SaveChanges() => throw new NotImplementedException();

        public override int SaveChanges(bool acceptAllChangesOnSuccess) => throw new NotImplementedException();

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public async Task SaveChangesAsync<T>(T aggregateRoot, CancellationToken cancellationToken) where T : AggregateRoot
        {
            // we added masstransit outbox pattern, so it will firstly add these events to the persistence, and publish them later,
            // it uses scoped version of current dbContext, so we don't have to use transaction here
            await _publishEndpoint.DispatchDomainEvents(aggregateRoot, cancellationToken);
            await base.SaveChangesAsync(cancellationToken);
        }
    }
}
