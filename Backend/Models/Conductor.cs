using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Conductor : Employee
    {
        [Required]
        public string role { get; set; }
    }
}