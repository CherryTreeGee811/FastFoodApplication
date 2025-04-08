namespace FastFoodAPI.Entities
{
    public class Training
    {
        public int TrainingId { get; set; }

        public string TrainingName { get; set; } = string.Empty;

        public string TrainingDescription { get; set; } = string.Empty;

        public ICollection<TrainingAssignment> TrainingAssignments { get; set; } = new List<TrainingAssignment>();
    }
}
