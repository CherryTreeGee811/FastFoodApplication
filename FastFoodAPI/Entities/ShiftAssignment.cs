namespace FastFoodAPI.Entities
{
    public class ShiftAssignment
    {
        public int ShiftId { get; set; }

        
        public Shift Shift { get; set; }


        public string EmployeeId { get; set; }


        public Employee Employee { get; set; }


        public DateTime ShiftDate { get; set; }
    }
}
