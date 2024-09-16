namespace Restaurant.Application.Dtos
{
    public record AddressDto
    {
        public Guid Id { get; init; }

        public string PostCode { get; init; }

        public string City { get; init; }

        public string Street { get; init; }

        public string BuildingNumber { get; init; }

        public string? FlatNumber { get; init; }
    }
}
