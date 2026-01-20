namespace Restaurant.Application.Dtos;

public record AddressDto
{
    public Guid Id { get; init; }

    public required string PostCode { get; init; }

    public required string City { get; init; }

    public required string Street { get; init; }

    public required string BuildingNumber { get; init; }

    public string? FlatNumber { get; init; }
}
