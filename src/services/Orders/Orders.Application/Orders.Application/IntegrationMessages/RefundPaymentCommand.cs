﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.IntegrationMessages
{
    public record RefundPaymentCommand
    {
        public Guid OrderId { get; init; }
    }
}
