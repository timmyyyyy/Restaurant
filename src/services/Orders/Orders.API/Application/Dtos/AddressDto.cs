namespace Orders.API.Application.Dtos
{
    public class AddressDto
    {
        public string PostCode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string BuildingNumber { get; set; }

        public string? FlatNumber { get; set; }
    }
}
