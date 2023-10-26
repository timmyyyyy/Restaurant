using System;

namespace Restaurant.Common.DomainBuildingBlocks
{
    public abstract class ValueObject
    {
        public int Id { get; private set; }

        public Guid RowGuid { get; private set; }

        // TODO
    }
}
