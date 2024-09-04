using MassTransit;
using Orders.Application.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Consumers
{
    public class ProcessOrderConsumer : IConsumer<ProcessOrderIntegrationEvent>
    {
        public Task Consume(ConsumeContext<ProcessOrderIntegrationEvent> context)
        {
            // TODO create routing slip here
        }
    }
}
