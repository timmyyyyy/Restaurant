using System;

namespace Restaurant.Common.InfrastructureBuildingBlocks.Persistence
{
    public abstract class BaseDbEntitySoftDeletable : BaseDbEntity, IDbEntityDeletable
    {
        public bool IsDeleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
