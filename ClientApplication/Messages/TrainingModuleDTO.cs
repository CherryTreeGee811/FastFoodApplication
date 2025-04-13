using System.Text.Json.Serialization;


namespace ClientApplication.Messages
{
    public class TrainingModuleDTO
    {
        [JsonPropertyName("trainingId")]
        public int TrainingId { get; set; }


        [JsonPropertyName("trainingName")]
        public string TrainingName { get; set; }
    }
}
