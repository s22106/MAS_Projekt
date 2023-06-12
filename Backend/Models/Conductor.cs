using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Conductor : Employee
    {
        [Required]
        public string bonus { get; set; }
    }
}