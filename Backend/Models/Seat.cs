using System.ComponentModel.DataAnnotations;
using Backend.Models.Enum;

namespace API.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        [Required]
        public int WagonId { get; set; }
        [Required]
        public int SeatNumber { get; set; }
        [Required]
        [EnumDataType(typeof(SeatType))]
        public SeatType Type { get; set; }
        public virtual Wagon Wagon { get; set; }
    }
}