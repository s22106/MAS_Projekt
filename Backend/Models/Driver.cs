using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Driver
    {
        public int DriverId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int bonus { get; set; }
        public virtual Employee Employee { get; set; }
    }
}