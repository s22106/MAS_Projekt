using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Enum;

namespace API.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        [Required]
        public int TransitId { get; set; }
        [Required]
        public int PassengerId { get; set; }
        // moze nie byc potrzebne
        public DateTime DepartureTime { get; set; }
        [Required]
        public Decimal Price { get; set; }
        // potencjalnie niepotrzebne
        [Required]
        public int Wagon { get; set; }
        [Required]
        public int Seat { get; set; }
        [Required]
        [EnumDataType(typeof(SeatType))]
        public SeatType SeatType { get; set; }
        public virtual Transit Transit { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}