using Restaurant.Common.DomainBuildingBlocks;

namespace Restaurant.Domain.Aggregates.Restaurant
{
    public sealed class Address : ValueObject
    {
        public string PostCode { get; init; }

        public string City { get; init; }

        public string Street { get; init; }

        public string BuildingNumber { get; init; }

        public string? FlatNumber { get; init; }
    }
}
