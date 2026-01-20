using System;

namespace Restaurant.Common.InfrastructureBuildingBlocks.Persistence;

public interface IDbEntityDeletable
{
    bool IsDeleted { get; set; }

    Guid? DeletedBy { get; set; }

    DateTime? DeletedDate { get; set; }

}
