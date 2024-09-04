using Microsoft.Extensions.Primitives;
using Restaurant.Common.DomainBuildingBlocks;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Common.InfrastructureBuildingBlocks.Repos
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync<T>(T aggregateRoot, CancellationToken cancellationToken) where T : AggregateRoot;
    }
}
