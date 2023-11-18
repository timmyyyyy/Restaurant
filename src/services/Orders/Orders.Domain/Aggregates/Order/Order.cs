using Restaurant.Common.DomainBuildingBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Aggregates.Order
{
    public class Order : AggregateRoot
    {
        public string EmailAddress { get; private set; }

        public string PhoneNumber { get; private set; }

        public Address DeliveryAddress { get; private set; }
    }
}
