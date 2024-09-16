namespace Restaurant.Infrastructure.Models
{
    public class MenuDbEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public RestaurantDbEntity Restaurant { get; set; }

        public Guid RestaurantId { get; set; }

        public IEnumerable<MenuItemDbEntity> Items { get; set; }
    }
}
