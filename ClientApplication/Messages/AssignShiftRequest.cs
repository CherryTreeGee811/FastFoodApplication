using System.Text.Json.Serialization;


namespace ClientApplication.Messages
{
    public class AssignShiftRequest
    {
        [JsonPropertyName("shiftId")]
        public int ShiftId { get; set; }


        [JsonPropertyName("shiftDate")]
        public DateTime ShiftDate { get; set; }
    }
}
