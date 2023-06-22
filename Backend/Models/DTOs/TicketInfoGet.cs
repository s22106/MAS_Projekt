using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.DTOs
{
    public class TicketInfoGet
    {
        public string startStation { get; set; }
        public string endStation { get; set; }
        public string date { get; set; }
        public int transitId { get; set; }
        public int seatNumber { get; set; }
        public int wagonNumber { get; set; }
    }
}