namespace Orders.Domain.Aggregates.Order.Parameters
{
    public record AddressCreationParams
    {
        public string PostCode { get; init; }

        public string City { get; init; }

        public string Street { get; init; }

        public string BuildingNumber { get; init; }

        public string? FlatNumber { get; init; }
    }
}
