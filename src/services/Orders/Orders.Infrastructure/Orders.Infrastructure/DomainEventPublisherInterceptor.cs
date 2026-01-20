using MassTransit;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Restaurant.Common.ApplicationBuildingBlocks;

namespace Orders.Infrastructure;

public class DomainEventPublisherInterceptor(IDomainEventCollector domainEventCollector) : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var isSagaOperation = eventData?.Context?.ChangeTracker?.Entries<SagaStateMachineInstance>()?.Count() > 0;

        if (!isSagaOperation)
        {
            return result;
        }

        await domainEventCollector.Dispatch(cancellationToken);

        return result;
    }
}
