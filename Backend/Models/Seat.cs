namespace API.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public int WagonId { get; set; }
        public int SeatNumber { get; set; }
        public string Type { get; set; }
        public virtual Wagon Wagon { get; set; }
    }
}