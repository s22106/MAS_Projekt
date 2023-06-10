using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Driver : Employee
    {
        [Required]
        public int DriverId { get; set; }
        [Required]
        public int bonus { get; set; }
    }
}