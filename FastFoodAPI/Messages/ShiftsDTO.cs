using System.Text.Json.Serialization;
using FastFoodAPI.Entities;

namespace FastFoodAPI.Messages
{
    public class ShiftsDTO
    {
        [JsonPropertyName("shiftId")]
        public int ShiftId { get; set; }

        [JsonPropertyName("shiftPosition")]
        public string? ShiftPosition { get; set; } = ShiftSchedule.Unassigned.ToString();
    
    }
}

