using Restaurant.Common.DomainBuildingBlocks;
using Restaurant.Common.FlowBuildingBlocks;

namespace Orders.Domain.Aggregates.Order
{
    public class Address : ValueObject
    {
        public string PostCode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string BuildingNumber { get; set; }

        public string? FlatNumber { get; set; }

        internal Address(string postCode, string city, string street, string buildingNumber, string? flatNumber)
        {
            PostCode = postCode;
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
            FlatNumber = flatNumber;
        }

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
