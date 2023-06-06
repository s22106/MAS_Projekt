namespace API.Models
{
    public class Driver
    {
        public int DriverId { get; set; }
        public int EmployeeId { get; set; }
        public int bonus { get; set; }
        public virtual Employee Employee { get; set; }
    }
}