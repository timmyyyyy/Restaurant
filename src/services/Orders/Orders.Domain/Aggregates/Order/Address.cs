using Restaurant.Common.DomainBuildingBlocks;

namespace Orders.Domain.Aggregates.Order
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
