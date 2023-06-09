using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        [Required]
        public int PersonId { get; set; }
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
        public virtual Person Person { get; set; }
        public virtual IEnumerable<Ticket> Tickets { get; set; }
    }
}