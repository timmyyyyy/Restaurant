using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Common.InfrastructureBuildingBlocks
{
    public class MigrationsHostedService<TDbContext> : IHostedService
        where TDbContext : DbContext
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public MigrationsHostedService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();

            using var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();

            await dbContext.Database.MigrateAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}