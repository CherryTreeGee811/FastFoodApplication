using System.Text.Json.Serialization;


namespace ClientApplication.Messages
{
    public class StationDTO
    {
        [JsonPropertyName("stationId")]
        public int StationId { get; set; }


        [JsonPropertyName("stationName")]
        public string StationName { get; set; } = string.Empty;
    }
}
