﻿using MassTransit;
using Restaurant.Common.FlowBuildingBlocks;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Common.DomainBuildingBlocks
{
    public static class DomainEventDispatcher
    {
        public static async Task DispatchDomainEvents(this MediatR.IMediator mediator, AggregateRoot aggregateRoot, CancellationToken cancellationToken)
        {
            foreach (var e in aggregateRoot.DomainEvents)
            {
                await mediator.Publish(e, cancellationToken);
            }
        }
    }
}
