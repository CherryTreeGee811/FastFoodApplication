namespace FastFoodAPI.Entities
{
    public class TrainingAssignment
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int TrainingId { get; set; }

        public Training Training { get; set; }

        public bool CompletedTraining { get; set; }

        public DateTime? DateCompleted { get; set; }
    }
}
