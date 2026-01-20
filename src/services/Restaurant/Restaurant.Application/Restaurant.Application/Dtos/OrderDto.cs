namespace Restaurant.Application.Dtos;

public record OrderDto
{
    public Guid Id { get; init; }

    public string? EmailAddress { get; init; }

    public string? PhoneNumber { get; init; }

    public Guid RestaurantId { get; init; }

    public Guid? CustomerId { get; init; }

    public required AddressDto DeliveryAddress { get; init; }

    public required List<Guid> MenuItemsIds { get; init; }

    public bool PaymentOnDelivery { get; init; }
}
