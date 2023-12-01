using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Aggregates.Order
{
    public enum OrderStatus
    {
        Draft = 0,
        Validated,
        Submitted,
        Cancelled,
        Declined,
        Accepted,
        Ready,
        Collected,
        Delivered,
        Refunded
    }
}
