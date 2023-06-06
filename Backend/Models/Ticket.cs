using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int TransitId { get; set; }
        public int UserId { get; set; }
        // moze nie byc potrzebne
        public DateTime DepartureTime { get; set; }
        public Decimal Price { get; set; }
        // potencjalnie niepotrzebne
        public int Waggon { get; set; }
        public int Seat { get; set; }
        public string SeatType { get; set; }
        public virtual Transit Transit { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}