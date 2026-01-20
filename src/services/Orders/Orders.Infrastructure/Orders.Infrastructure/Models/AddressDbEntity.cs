using Orders.Domain.Aggregates.Order;
using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;

namespace Orders.Infrastructure.Models;

public class AddressDbEntity : BaseDbEntity
{
    internal AddressDbEntity() { }

    public required string PostCode { get; set; }

    public required string City { get; set; }

    public required string Street { get; set; }

    public required string BuildingNumber { get; set; }

    public string? FlatNumber { get; set; }

    public static explicit operator Address(AddressDbEntity entity)
        => new(entity.PostCode, entity.City, entity.Street, entity.BuildingNumber, entity.FlatNumber);

    public static explicit operator AddressDbEntity(Address address)
        => new()
        {
            PostCode = address.PostCode,
            City = address.City,
            Street = address.Street,
            BuildingNumber = address.BuildingNumber,
            FlatNumber = address.FlatNumber
        };
}
