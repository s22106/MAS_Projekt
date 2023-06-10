using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CompartmentWagon : Wagon
    {
        public int CompartmentWagonId { get; set; }
        [Required]
        public int NumberOfCompartments { get; set; }
        public virtual Wagon Wagon { get; set; }
    }
}