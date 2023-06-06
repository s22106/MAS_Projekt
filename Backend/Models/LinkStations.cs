using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class LinkStations
    {
        public int LinkId { get; set; }
        public int StationId { get; set; }
        public int Number { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public virtual RailLink Link { get; set; }
        public virtual TrainStation Station { get; set; }
    }
}