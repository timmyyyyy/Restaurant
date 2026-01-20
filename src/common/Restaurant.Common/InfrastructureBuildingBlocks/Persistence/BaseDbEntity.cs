using System;

namespace Restaurant.Common.InfrastructureBuildingBlocks.Persistence;

public abstract class BaseDbEntity : IDbEntityAuditable
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
