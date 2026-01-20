using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;
using Restaurant.Domain.Aggregates.Restaurant;

namespace Restaurant.Infrastructure.Models;

public class WorkingScheduleDbEntity : BaseDbEntitySoftDeletable
{
    internal WorkingScheduleDbEntity() { }

    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly Start { get; set; }

    public TimeOnly End { get; set; }

    public static WorkingSchedule ToWorkingScheduleDomainObject(IEnumerable<WorkingScheduleDbEntity> entities)
    {
        return new()
        {
            Schedule = entities.ToDictionary(x => x.DayOfWeek, x => new WorkingHours() { Start = x.Start, End = x.End })
        };
    }
}
