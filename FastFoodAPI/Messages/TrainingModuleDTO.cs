using System.Text.Json.Serialization;


namespace FastFoodAPI.Messages
{
    public class TrainingModuleDTO
    {
        [JsonPropertyName("trainingId")]
        public int TrainingId { get; set; }


        [JsonPropertyName("trainingName")]
        public string TrainingName { get; set; }


        [JsonPropertyName("trainingDescription")]
        public string? TrainingDescription { get; set; }


        [JsonPropertyName("completedTraining")]
        public bool? CompletedTraining { get; set; }


        [JsonPropertyName("dateCompleted")]
        public DateTime? DateCompleted { get; set; }
    }
}
