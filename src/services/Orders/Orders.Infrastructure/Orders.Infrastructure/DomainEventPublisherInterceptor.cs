using MassTransit;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Restaurant.Common.ApplicationBuildingBlocks;

namespace Orders.Infrastructure
{
    public class DomainEventPublisherInterceptor : SaveChangesInterceptor
    {
        private readonly IDomainEventCollector _domainEventCollector;

        public DomainEventPublisherInterceptor(IDomainEventCollector domainEventCollector)
        {
            _domainEventCollector = domainEventCollector;
        }

        public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var isSagaOperation = eventData?.Context?.ChangeTracker?.Entries<SagaStateMachineInstance>()?.Count() > 0;

            if (!isSagaOperation)
            {
                return result;
            }

            await _domainEventCollector.Dispatch();

            return result;
        }
    }
}
