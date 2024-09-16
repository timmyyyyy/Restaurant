namespace Restaurant.Infrastructure.Models
{
    public class WorkingScheduleDbEntity
    {
        public Guid Id { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeOnly Start { get; set; }

        public TimeOnly End { get; set; }
    }
}
