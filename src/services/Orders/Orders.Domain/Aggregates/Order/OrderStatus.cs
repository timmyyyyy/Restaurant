namespace Orders.Domain.Aggregates.Order;

public enum OrderStatus
{
    Draft = 0,
    Validated,
    Submitted,
    Cancelled,
    Declined,
    Accepted,
    Ready,
    Collected,
    Delivered,
    Refunded
}
