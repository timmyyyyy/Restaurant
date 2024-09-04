namespace Restaurant.Application
{
    public class ValidateOrderCommand
    {
        public ValidateOrderCommand(Guid orderId, Guid restaurantId, IEnumerable<Guid> menuItemsIds)
        {
            OrderId = orderId;
            RestaurantId = restaurantId;
            MenuItemsIds = menuItemsIds;
        }

        public Guid OrderId { get; private set; }

        public Guid RestaurantId { get; private set; }

        public IEnumerable<Guid> MenuItemsIds { get; private set; }
    }
}
