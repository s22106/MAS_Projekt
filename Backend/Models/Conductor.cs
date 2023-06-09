using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Conductor
    {
        public int ConductorId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string bonus { get; set; }
        public virtual Employee Employee { get; set; }
    }
}