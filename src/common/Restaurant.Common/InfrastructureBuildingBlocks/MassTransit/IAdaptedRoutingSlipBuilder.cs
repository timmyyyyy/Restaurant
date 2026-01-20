using MassTransit;
using MassTransit.Courier;

namespace Restaurant.Common.InfrastructureBuildingBlocks.MassTransit;

public interface IAdaptedRoutingSlipBuilder : IRoutingSlipBuilder, IRoutingSlipSendEndpointTarget
{
    void AddActivity(string name);
}
