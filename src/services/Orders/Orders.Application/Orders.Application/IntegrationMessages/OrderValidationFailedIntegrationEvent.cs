﻿namespace Orders.Application.IntegrationMessages
{
    public record OrderValidationFailedIntegrationEvent
    {
        // TODO list with validation errors

        public Guid OrderId { get; init; }
    }
}