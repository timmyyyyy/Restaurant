using Orders.Domain.Aggregates.Order.Parameters;
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

        internal static OperationResult<Address> CreateAddress(AddressCreationParams input)
        {
            if (string.IsNullOrEmpty(input.PostCode) || string.IsNullOrEmpty(input.City) || 
                string.IsNullOrEmpty(input.Street) || string.IsNullOrEmpty(input.BuildingNumber))
            {
                // TODO
                var exception = new Exception();
                return new OperationResult<Address>(exception);
            }

            var address = new Address(input.PostCode, input.City, input.Street, input.BuildingNumber, input.FlatNumber);
            return new OperationResult<Address>(address);
        }
    }
}
