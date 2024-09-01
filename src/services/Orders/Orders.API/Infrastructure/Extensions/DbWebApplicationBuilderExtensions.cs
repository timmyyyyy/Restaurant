using Microsoft.EntityFrameworkCore;
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
    }
}
