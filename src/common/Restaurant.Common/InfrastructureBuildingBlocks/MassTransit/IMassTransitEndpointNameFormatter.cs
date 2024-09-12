namespace Restaurant.Common.InfrastructureBuildingBlocks.MassTransit
{
    public interface IMassTransitEndpointNameFormatter
    {
        string FormatName(string name, MassTransitEndpointOperationType operationType);
    }
}
