using MassTransit;
using Microsoft.EntityFrameworkCore;
using Orders.Domain.StateMachines;
using Restaurant.Common.InfrastructureBuildingBlocks;
using System.Reflection;

namespace Orders.API.Infrastructure.Extensions
{
    public static class DbWebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddDbConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<OrdersDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("Default");
                options.UseSqlServer(connectionString, builder =>
                {
                    builder.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
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

                x.AddSagaStateMachine<OrderStateMachine, OrderState>()
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
            });

            return builder;
        }
    }
}
