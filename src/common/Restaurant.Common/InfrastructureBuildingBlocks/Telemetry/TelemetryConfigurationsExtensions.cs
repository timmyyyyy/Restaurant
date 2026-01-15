using System;
using System.Diagnostics;
using MassTransit.Metadata;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Restaurant.Common.InfrastructureBuildingBlocks.Telemetry
{
    public static class TelemetryConfigurationExtensions
    {
        public static void AddOpenTelemetry(this IServiceCollection services, string serviceName)
        {
            services.AddOpenTelemetry()
                .WithMetrics(builder =>
                {
                    builder
                        .AddMeter("MassTransit")
                        .SetResourceBuilder(ResourceBuilder.CreateDefault()
                            .AddService(serviceName)
                            .AddTelemetrySdk()
                            .AddEnvironmentVariableDetector())
                        .AddPrometheusExporter();
                })
                .WithTracing(builder =>
                {
                    builder
                        .AddSource("MassTransit")
                        .SetResourceBuilder(ResourceBuilder.CreateDefault()
                            .AddService(serviceName)
                            .AddTelemetrySdk()
                            .AddEnvironmentVariableDetector())
                        .AddAspNetCoreInstrumentation()
                        .AddSqlClientInstrumentation(o =>
                        {
                            o.EnableConnectionLevelAttributes = true;
                            o.RecordException = true;
                            o.SetDbStatementForText = true;
                        })
                        .AddOtlpExporter(o =>
                        {
                            o.Endpoint = new Uri(HostMetadataCache.IsRunningInContainer ? "http://tempo:4317" : "http://localhost:4317");
                        });
                });
        }

        public static void UseOpenTelemetry(this WebApplication app)
        {
            app.MapPrometheusScrapingEndpoint();
        }
    }
}
