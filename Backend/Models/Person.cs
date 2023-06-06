namespace API.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Passenger? Passenger { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}