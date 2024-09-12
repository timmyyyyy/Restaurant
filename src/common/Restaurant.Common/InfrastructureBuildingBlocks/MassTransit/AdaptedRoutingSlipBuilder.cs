using MassTransit;
using System;

namespace Restaurant.Common.InfrastructureBuildingBlocks.MassTransit
{
    public class AdaptedRoutingSlipBuilder : RoutingSlipBuilder, IAdaptedRoutingSlipBuilder
    {
        private readonly IMassTransitEndpointNameFormatter _massTransitEndpointNameFormatter;

        public AdaptedRoutingSlipBuilder(IMassTransitEndpointNameFormatter massTransitEndpointNameFormatter) : base(NewId.NextGuid())
        {
            _massTransitEndpointNameFormatter = massTransitEndpointNameFormatter;
        }

        public void AddActivity(string name)
        {
            var endpointFormatted = _massTransitEndpointNameFormatter.FormatName(name, MassTransitEndpointOperationType.Activity);
            this.AddActivity(name, new Uri(endpointFormatted));
        }
    }
}
