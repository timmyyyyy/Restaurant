using System;

namespace Restaurant.Common.ApplicationBuildingBlocks;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}
