namespace Orders.Infrastructure.Models
{
    public class Address
    {
        public string PostCode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string BuildingNumber { get; set; }

        public string? FlatNumber { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
