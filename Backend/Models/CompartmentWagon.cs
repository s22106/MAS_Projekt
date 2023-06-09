using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CompartmentWagon
    {
        public int CompartmentWagonId { get; set; }
        [Required]
        public int WagonId { get; set; }
        [Required]
        public int NumberOfCompartments { get; set; }
        public virtual Wagon Wagon { get; set; }
    }
}