using OpenTelemetry.Metrics;
using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;
using Restaurant.Domain.Aggregates.Restaurant;

namespace Restaurant.Infrastructure.Models
{
    public class RestaurantDbEntity : BaseDbEntitySoftDeletable
    {
        public string Name { get; set; }

        public AddressDbEntity Address { get; set; }

        public IEnumerable<WorkingScheduleDbEntity> WorkingSchedule { get; set; }

        public IEnumerable<MenuDbEntity> Menus { get; private set; }

        public static explicit operator Domain.Aggregates.Restaurant.Restaurant(RestaurantDbEntity entity)
        {
            return new()
            {
                Id = entity.Id,
                MenuIds = entity.Menus?.Select(x => x.Id)?.ToList(),
                Name = entity.Name,
                Address = (Address)entity.Address,
                WorkingSchedule = WorkingScheduleDbEntity.ToWorkingScheduleDomainObject(entity.WorkingSchedule),
            };
        }
    }
}
