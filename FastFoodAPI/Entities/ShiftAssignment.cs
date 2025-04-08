namespace FastFoodAPI.Entities
{
    public class ShiftAssignment
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int ShiftId { get; set; }

        public Shift Shift { get; set; }

        public DateTime ShiftDate { get; set; }
    }
}
