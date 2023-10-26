using Restaurant.Common.DomainBuildingBlocks;

namespace Restaurant.Domain.Aggregates.Restaurant
{
    public class Address : ValueObject
    {
        public string PostCode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string BuildingNumber { get; set; }

        public string? FlatNumber { get; set; }
    }
}
