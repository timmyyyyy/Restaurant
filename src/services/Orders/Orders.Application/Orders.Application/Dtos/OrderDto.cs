namespace Orders.Application.Dtos
{
    public record OrderDto
    {
        public Guid Id { get; init; }
        // TODO

        public bool PaymentOnDelivery { get; init; }
    }
}
