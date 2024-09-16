namespace Restaurant.Infrastructure.Models
{
    public class RestaurantDbEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public AddressDbEntity Address { get; set; }

        public WorkingScheduleDbEntity WorkingSchedule { get; set; }

        public IEnumerable<MenuDbEntity> Menus { get; private set; }
    }
}
