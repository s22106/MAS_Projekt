namespace API.Models
{
    public abstract class Employee
    {
        public int EmployeeId { get; set; }
        public int TrainId { get; set; }
        public int PersonId { get; set; }
        public DateTime EmploymentDate { get; set; }
        public virtual Train Train { get; set; }
        public virtual Driver? Driver { get; set; }
        public virtual Conductor? Conductor { get; set; }
    }
}