using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Restaurant.Common.ApplicationBuildingBlocks;
using Restaurant.Common.InfrastructureBuildingBlocks.DI;

namespace Restaurant.Domain.Aggregates.Menu;

public interface IMenuRepository : IScopedDependency
{
    Task<OperationResult<Menu>> GetMenu(Guid id, CancellationToken cancellationToken = default);

    Task<OperationResult<IEnumerable<Menu>>> GetMenus(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
}
