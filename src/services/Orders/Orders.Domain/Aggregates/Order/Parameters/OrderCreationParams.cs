namespace Orders.Domain.Aggregates.Order.Parameters;

public record OrderCreationParams
{
    public string? EmailAddress { get; init; }

    public string? PhoneNumber { get; init; }

    public Guid RestaurantId { get; init; }

    public Guid? CustomerId { get; init; }

    public required List<Guid> MenuItemsIds { get; init; }

    public bool PaymentOnDelivery { get; init; }

    public required AddressCreationParams AddressCreationParams { get; init; }
}
