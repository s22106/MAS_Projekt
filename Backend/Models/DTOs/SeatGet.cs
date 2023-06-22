using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.DTOs
{
    public class SeatGet
    {
        public int WagonNumber { get; set; }
        public int SeatNumber { get; set; }
    }
}