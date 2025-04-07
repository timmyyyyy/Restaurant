using System;

namespace Restaurant.Common.DomainBuildingBlocks
{
    public class DomainException : Exception
    {
        public DomainException(string? message) : base(message)
        {
        }
    }
}
