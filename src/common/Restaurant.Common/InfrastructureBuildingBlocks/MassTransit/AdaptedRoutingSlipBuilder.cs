using System;
using MassTransit;

namespace Restaurant.Common.InfrastructureBuildingBlocks.MassTransit;

public class AdaptedRoutingSlipBuilder(IMassTransitEndpointNameFormatter massTransitEndpointNameFormatter) : RoutingSlipBuilder(NewId.NextGuid()), IAdaptedRoutingSlipBuilder
{
    public void AddActivity(string name)
    {
        var endpointFormatted = massTransitEndpointNameFormatter.FormatName(name, MassTransitEndpointOperationType.Activity);
        this.AddActivity(name, new Uri(endpointFormatted));
    }
}
