using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Enum;

namespace Backend.Models.DTOs
{
    public class LinkStationGet
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public TimeOnly? DepartureTime { get; set; }
        public TimeOnly? ArrivalTime { get; set; }
        public StationType? Type { get; set; }
    }
}