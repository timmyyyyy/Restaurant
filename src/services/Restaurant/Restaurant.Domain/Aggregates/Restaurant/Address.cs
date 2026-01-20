using Restaurant.Common.DomainBuildingBlocks;

namespace Restaurant.Domain.Aggregates.Restaurant;

public sealed record Address : ValueObject
{
    public required string PostCode { get; init; }

    public required string City { get; init; }

    public required string Street { get; init; }

    public required string BuildingNumber { get; init; }

    public string? FlatNumber { get; init; }
}
