using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Enum;

namespace Backend.Models.DTOs
{
    public class TicketGet
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Price { get; set; }
        public int SeatNumber { get; set; }
        public int WagonNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public string StartStation { get; set; }
        public string EndStation { get; set; }
        public SeatType SeatType { get; set; }
    }
}