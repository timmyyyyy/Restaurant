using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;
using System.Reflection.Metadata.Ecma335;

namespace Restaurant.Infrastructure.Models
{
    public class AddressDbEntity : BaseDbEntitySoftDeletable
    {
        public string PostCode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string BuildingNumber { get; set; }

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
}
