namespace Restaurant.IntegrationMessages;

public record RefundPaymentCommand
{
    public Guid OrderId { get; init; }
}
