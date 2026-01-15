namespace Restaurant.Contracts
{
    public class ValidateOrderCommand(Guid orderId, Guid restaurantId, IEnumerable<Guid> menuItemsIds)
    {
        public Guid OrderId { get; private set; } = orderId;

        public Guid RestaurantId { get; private set; } = restaurantId;

        public IEnumerable<Guid> MenuItemsIds { get; private set; } = menuItemsIds;
    }
}
