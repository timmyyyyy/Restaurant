using Orders.Domain.Aggregates.Order.Parameters;
using Restaurant.Common.ApplicationBuildingBlocks;
using Restaurant.Common.DomainBuildingBlocks;

namespace Orders.Domain.Aggregates.Order;

public sealed record Address : ValueObject
{
    internal Address(string postCode, string city, string street, string buildingNumber, string? flatNumber)
    {
        PostCode = postCode;
        City = city;
        Street = street;
        BuildingNumber = buildingNumber;
        FlatNumber = flatNumber;
    }

    public string PostCode { get; init; }

    public string City { get; init; }

    public string Street { get; init; }

    public string BuildingNumber { get; init; }

    public string? FlatNumber { get; init; }

    internal static OperationResult<Address> CreateAddress(AddressCreationParams input)
    {
        if (string.IsNullOrWhiteSpace(input.PostCode) || string.IsNullOrWhiteSpace(input.City) ||
            string.IsNullOrWhiteSpace(input.Street) || string.IsNullOrWhiteSpace(input.BuildingNumber))
        {
            return OperationResult<Address>.Failed(new ArgumentException("Address fields cannot be empty"));
        }

        var address = new Address(input.PostCode, input.City, input.Street, input.BuildingNumber, input.FlatNumber);
        return OperationResult<Address>.Success(address);
    }
}
