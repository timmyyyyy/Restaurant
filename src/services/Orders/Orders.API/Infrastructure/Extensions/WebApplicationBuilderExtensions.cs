using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Orders.Application;
using Orders.Application.StateMachines;
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
            builder.Services.AddScoped<SaveChangesInterceptor, DomainEventPublisherInterceptor>();

            builder.Services.AddDbContext<OrdersDbContext>((sp, options) =>
            {
                var connectionString = builder.Configuration.GetConnectionString("OrdersDb") 
                    ?? builder.Configuration.GetConnectionString("Default");
                    
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(InfrastructureMarker).Assembly.FullName);
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                });

                var interceptors = sp.GetRequiredService<SaveChangesInterceptor>();
                options.AddInterceptors(interceptors);
            });

            builder.Services.AddHostedService<MigrationsHostedService<OrdersDbContext>>();

            return builder;
        }

        public static WebApplicationBuilder AddMassTransitConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                x.AddSagaStateMachine<OrderStateMachine, OrderSagaStateDbEntity>()
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
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("admin");
                        h.Password("admin123");
                    });
                    
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
