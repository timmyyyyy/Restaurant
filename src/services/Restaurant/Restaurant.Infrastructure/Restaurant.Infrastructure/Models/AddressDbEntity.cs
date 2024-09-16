namespace Restaurant.Infrastructure.Models
{
    public class AddressDbEntity
    {
        public Guid Id { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string BuildingNumber { get; set; }

        public string? FlatNumber { get; set; }
    }
}
