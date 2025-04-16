using System.ComponentModel.DataAnnotations;

namespace FastFoodAPI.Messages
{
    /// <summary>
    /// Data transfer object for updating a shift assignment.
    /// </summary>
    public class UpdateShiftRequest
    {
        /// <summary>
        /// The original date of the shift assignment to update.
        /// </summary>
        [Required]
        public DateTime OriginalShiftDate { get; set; }

        /// <summary>
        /// The new shift ID to assign. Set to 0 to keep the current shift ID.
        /// </summary>
        public int NewShiftId { get; set; }

        /// <summary>
        /// The new date for the shift assignment. Set to null to keep the current date.
        /// </summary>
        public DateTime? NewShiftDate { get; set; }
    }
}
