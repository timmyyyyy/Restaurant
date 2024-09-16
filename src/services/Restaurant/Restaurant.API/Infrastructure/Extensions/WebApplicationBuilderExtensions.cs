using MassTransit;
using Microsoft.EntityFrameworkCore;
using Restaurant.Common.InfrastructureBuildingBlocks;
using Restaurant.Common.InfrastructureBuildingBlocks.MassTransit;
using Restaurant.Infrastructure;
using System.Reflection;

namespace Restaurant.API.Infrastructure.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddDbConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<RestaurantDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("Default");
                options.UseSqlServer(connectionString, builder =>
                {
                    builder.MigrationsAssembly(typeof(InfrastructureMarker).Assembly.FullName);
                });
            });

            builder.Services.AddHostedService<MigrationsHostedService<RestaurantDbContext>>();

            return builder;
        }

        public static WebApplicationBuilder AddMassTransitConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                x.AddEntityFrameworkOutbox<RestaurantDbContext>(x =>
                {
                    x.UseSqlServer();

                    x.UseBusOutbox();
                });

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });


            builder.Services.AddOptions<MassTransitHostOptions>()
                .Configure(options =>
                {
                    options.WaitUntilStarted = true;
                });

            builder.Services.AddSingleton<IMassTransitEndpointNameFormatter, RabbitMqEndpointNameFormatter>();
            builder.Services.AddTransient<IAdaptedRoutingSlipBuilder, AdaptedRoutingSlipBuilder>();


            return builder;
        }
    }
}
