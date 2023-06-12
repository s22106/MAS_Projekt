using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CompartmentWagon : Wagon
    {
        [Required]
        public int NumberOfCompartments { get; set; }
        public virtual Wagon Wagon { get; set; }
    }
}