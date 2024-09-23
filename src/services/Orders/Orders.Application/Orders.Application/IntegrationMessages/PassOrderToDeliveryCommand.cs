using Orders.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.IntegrationMessages
{
    public record PassOrderToDeliveryCommand
    {
        public PassOrderToDeliveryCommand(OrderDto order)
        {
            Order = order;
        }

        public OrderDto Order { get; private set; }
    }
}
