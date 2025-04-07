using Restaurant.Common.DomainBuildingBlocks;
using Restaurant.Common.FlowBuildingBlocks;

namespace Orders.Domain.Aggregates.Order
{
    public sealed class Address : ValueObject
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

        public static OperationResult<Address> CreateAddress(string postCode, string city, string street,
            string buildingNumber, string? flatNumber)
        {
            if (string.IsNullOrEmpty(postCode) || string.IsNullOrEmpty(city) || 
                string.IsNullOrEmpty(street) || string.IsNullOrEmpty(buildingNumber))
            {
                // TODO
                var exception = new Exception();
                return new OperationResult<Address>(exception);
            }

            var address = new Address(postCode, city, street, buildingNumber, flatNumber);
            return new OperationResult<Address>(address);
        }
    }
}
