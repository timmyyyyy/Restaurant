using System;

namespace Restaurant.Common.InfrastructureBuildingBlocks.MassTransit
{
    public class RabbitMqEndpointNameFormatter : IMassTransitEndpointNameFormatter
    {
        public string FormatName(string name, MassTransitEndpointOperationType operationType) =>
            $"exchange:{name}_{GetOperationTypeName(operationType)}";

        private string GetOperationTypeName(MassTransitEndpointOperationType operationType) =>
            operationType switch
            {
                MassTransitEndpointOperationType.Activity => "execute",
                _ => throw new NotImplementedException()
            };
    }
}
