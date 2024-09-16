namespace Restaurant.Infrastructure.Models
{
    public class MenuItemAvailabilityDbEntity
    {
        public Guid Id {  get; set; }

        public MenuItemAvailabilityType MenuItemAvailabilityType { get; set; }

        public string ItemAvailabilityJSON { get; set; }
    }
}
