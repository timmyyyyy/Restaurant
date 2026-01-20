using System;

namespace Restaurant.Common.DomainBuildingBlocks;

public abstract class Entity
{
    public Guid Id { get; init; }
}
