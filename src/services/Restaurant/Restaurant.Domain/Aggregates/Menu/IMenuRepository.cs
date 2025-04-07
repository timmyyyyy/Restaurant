using Restaurant.Common.FlowBuildingBlocks;
using Restaurant.Common.InfrastructureBuildingBlocks.DI;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Domain.Aggregates.Menu
{
    public interface IMenuRepository : IScopedDependency
    {
        Task<OperationResult<Menu>> GetMenu(Guid id);

        Task<OperationResult<IEnumerable<Menu>>> GetMenus(IEnumerable<Guid> ids);
    }
}
