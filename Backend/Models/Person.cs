using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public abstract class Person
    {
        public int PersonId { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        public virtual Passenger? Passenger { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}