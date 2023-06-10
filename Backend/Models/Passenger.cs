using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class Passenger : Person
    {
        public int PassengerId { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(30)]
        public string Pasword { get; set; }
        public virtual IEnumerable<Ticket> Tickets { get; set; }
        public virtual Person Person { get; set; }
    }
}