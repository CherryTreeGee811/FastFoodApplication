using System.Text.Json.Serialization;


namespace ClientApplication.Messages
{
    public class ShiftsDTO
    {
        [JsonPropertyName("shiftId")]
        public int ShiftId { get; set; }

        [JsonPropertyName("shiftPosition")]
        public string? ShiftPosition { get; set; }

        [JsonPropertyName("employeeId")]
        public string? EmployeeId { get; set; }

        [JsonPropertyName("shiftDate")]
        public DateTime? ShiftDate { get; set; }
    }
}

