using System;

namespace Restaurant.Common.InfrastructureBuildingBlocks.Persistence
{
    public interface IDbEntityAuditable
    {
        Guid CreatedBy { get; set; }

        DateTime CreatedDate { get; set; }

        Guid? UpdatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }
    }
}
