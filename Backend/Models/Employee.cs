using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public abstract class Employee : Person
    {
        public int EmployeeId { get; set; }
        [Required]
        public int TrainId { get; set; }
        [Required]
        public DateTime EmploymentDate { get; set; }
        public virtual Train Train { get; set; }
        public virtual Person Person { get; set; }
    }
}