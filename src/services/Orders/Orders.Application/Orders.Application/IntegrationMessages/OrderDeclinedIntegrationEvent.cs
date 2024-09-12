﻿namespace Orders.Application.IntegrationMessages
{
    public record OrderDeclinedIntegrationEvent : IBaseOrderMessage
    {
        public Guid OrderId { get; init; }

        public string Reason { get; init; }
    }
}
