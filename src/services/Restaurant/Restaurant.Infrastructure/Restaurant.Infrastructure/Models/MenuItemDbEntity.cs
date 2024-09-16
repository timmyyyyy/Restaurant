namespace Restaurant.Infrastructure.Models
{
    public class MenuItemDbEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public MenuItemCategoryDbEntity ItemCategory { get; set; }

        public int? Grammage { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<MenuItemAvailabilityDbEntity> Availability { get; set; }

        public bool IsCurrentlyDisabled { get; set; }
    }
}
