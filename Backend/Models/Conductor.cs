namespace API.Models
{
    public class Conductor
    {
        public int ConductorId { get; set; }
        public int EmployeeId { get; set; }
        public string bonus { get; set; }
        public virtual Employee Employee { get; set; }
    }
}