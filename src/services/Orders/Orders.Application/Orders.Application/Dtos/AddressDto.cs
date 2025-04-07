using Orders.Domain.Aggregates.Order;
using Orders.Infrastructure.Models;

namespace Orders.Application.Dtos
{
    public record AddressDto
    {
        public string PostCode { get; init; }

        public string City { get; init; }

        public string Street { get; init; }

        public string BuildingNumber { get; init; }

        public string? FlatNumber { get; init; }

        public static explicit operator AddressDto (Address address)
        {
            return new()
            {
                PostCode = address.PostCode,
                City = address.City,
                Street = address.Street,
                BuildingNumber = address.BuildingNumber,
                FlatNumber = address.FlatNumber
            };
        }

        public static explicit operator AddressDbEntity (AddressDto address)
        {
            return new()
            {
                PostCode = address.PostCode,
                City = address.City,
                Street = address.Street,
                BuildingNumber = address.BuildingNumber,
                FlatNumber = address.FlatNumber
            };
        }

        public static explicit operator AddressDto(AddressDbEntity address)
        {
            return new()
            {
                PostCode = address.PostCode,
                City = address.City,
                Street = address.Street,
                BuildingNumber = address.BuildingNumber,
                FlatNumber = address.FlatNumber
            };
        }
    }
}
