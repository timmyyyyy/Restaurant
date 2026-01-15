using MassTransit;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application;
using Restaurant.Application.Consumers;
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
                var connectionString = builder.Configuration.GetConnectionString("RestaurantDb") 
                    ?? builder.Configuration.GetConnectionString("Default");
                    
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(InfrastructureMarker).Assembly.FullName);
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
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
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("admin");
                        h.Password("admin123");
                    });
                    
                    cfg.ConfigureEndpoints(context);
                });

                x.AddConsumersFromNamespaceContaining<ApplicationMarker>();
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
