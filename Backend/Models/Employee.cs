using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public abstract class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public int TrainId { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public DateTime EmploymentDate { get; set; }
        public virtual Train Train { get; set; }
        public virtual Person? Person { get; set; }
        public virtual Driver? Driver { get; set; }
        public virtual Conductor? Conductor { get; set; }
    }
}