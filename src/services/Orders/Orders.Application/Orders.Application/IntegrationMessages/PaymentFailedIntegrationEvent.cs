using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.IntegrationMessages
{
    public record PaymentFailedIntegrationEvent : IBaseOrderMessage
    {
        public Guid OrderId { get; init; }
    }
}
