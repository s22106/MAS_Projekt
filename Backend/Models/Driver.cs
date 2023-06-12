using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Driver : Employee
    {
        [Required]
        public int bonus { get; set; }
    }
}