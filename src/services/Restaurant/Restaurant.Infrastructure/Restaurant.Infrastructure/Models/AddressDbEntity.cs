using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;

namespace Restaurant.Infrastructure.Models;

public class AddressDbEntity : BaseDbEntitySoftDeletable
{
    internal AddressDbEntity() { }

    public required string PostCode { get; set; }

    public required string City { get; set; }

    public required string Street { get; set; }

    public required string BuildingNumber { get; set; }

    public string? FlatNumber { get; set; }

    public static explicit operator Domain.Aggregates.Restaurant.Address(AddressDbEntity entity)
        => new()
        {
            BuildingNumber = entity.BuildingNumber,
            City = entity.City,
            Street = entity.Street,
            FlatNumber = entity.FlatNumber,
            PostCode = entity.PostCode,
        };
}
