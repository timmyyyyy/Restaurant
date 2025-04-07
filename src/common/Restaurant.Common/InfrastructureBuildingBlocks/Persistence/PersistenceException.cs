using System;

namespace Restaurant.Common.InfrastructureBuildingBlocks.Persistence
{
    public class PersistenceException : Exception
    {
        public PersistenceException(string? message) : base(message)
        {
        }
    }
}
