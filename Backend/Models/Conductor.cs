using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Conductor : Employee
    {
        [Required]
        public int ConductorId { get; set; }
        [Required]
        public string bonus { get; set; }
    }
}