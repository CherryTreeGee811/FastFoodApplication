namespace FastFoodAPI.Entities
{
    public enum ShiftSchedule
    {
        Unassigned,
        Day,
        Afternoon,
        Night
    }

    public class Shift
    {
        public int ShiftId { get; set; }

        public ShiftSchedule ShiftPosition { get; set; } = ShiftSchedule.Unassigned;
    }
}
