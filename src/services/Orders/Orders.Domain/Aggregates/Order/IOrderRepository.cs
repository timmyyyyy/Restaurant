namespace Orders.Domain.Aggregates.Order
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);
    }
}
