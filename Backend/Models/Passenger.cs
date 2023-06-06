namespace API.Models
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public int PersonId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Pasword { get; set; }
        public virtual Person Person { get; set; }
        public virtual IEnumerable<Ticket> Tickets { get; set; }
    }
}