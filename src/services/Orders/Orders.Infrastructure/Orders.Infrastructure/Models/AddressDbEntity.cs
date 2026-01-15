using Orders.Domain.Aggregates.Order;
using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;

namespace Orders.Infrastructure.Models
{
    public class AddressDbEntity : BaseDbEntity
    {
        public AddressDbEntity() { }

        public AddressDbEntity(string postCode, string city, string street, string buildingNumber, string? flatNumber)
        {
            PostCode = postCode;
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
            FlatNumber = flatNumber;
        }

        public string PostCode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string BuildingNumber { get; set; }

        public string? FlatNumber { get; set; }

        public static explicit operator Address(AddressDbEntity entity)
            => new(entity.PostCode, entity.City, entity.Street, entity.BuildingNumber, entity.FlatNumber);

        public static explicit operator AddressDbEntity(Address address)
            => new(address.PostCode, address.City, address.Street, address.BuildingNumber, address.FlatNumber);
    }
}
