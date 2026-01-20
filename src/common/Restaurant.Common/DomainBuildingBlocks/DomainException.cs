using System;

namespace Restaurant.Common.DomainBuildingBlocks;

public class DomainException(string? message) : Exception(message)
{
}
