using MassTransit;
using Microsoft.EntityFrameworkCore;
using Orders.Application;
using Orders.Domain.StateMachines;
using Orders.Infrastructure;
using Orders.Infrastructure.Models;
using Restaurant.Common.InfrastructureBuildingBlocks;
using Restaurant.Common.InfrastructureBuildingBlocks.MassTransit;
using System.Reflection;

namespace Orders.API.Infrastructure.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddDbConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<OrdersDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("Default");
                options.UseSqlServer(connectionString, builder =>
                {
                    builder.MigrationsAssembly(typeof(InfrastructureMarker).Assembly.FullName);
                });
            });

            builder.Services.AddHostedService<MigrationsHostedService<OrdersDbContext>>();

            return builder;
        }

        public static WebApplicationBuilder AddMassTransitConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                x.AddSagaStateMachine<OrderStateMachine, OrderDbEntity>()
                    .EntityFrameworkRepository(x =>
                    {
                        // TODO concurrency mode
                        x.ExistingDbContext<OrdersDbContext>();
                    });

                x.AddEntityFrameworkOutbox<OrdersDbContext>(x =>
                {
                    x.UseSqlServer();

                    x.UseBusOutbox();
                });

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });

                x.AddActivitiesFromNamespaceContaining<ApplicationMarker>();
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
