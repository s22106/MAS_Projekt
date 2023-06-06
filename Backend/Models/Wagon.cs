using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public abstract class Wagon
    {
        public int WagonId { get; set; }
        public int TrainId { get; set; }
        public int classId { get; set; }
        public int NuberOfSeats { get; set; }
        public bool? IsSeatRequired { get; set; }
        public int WagonNumber { get; set; }
        public virtual OpenWagon OpenWagon { get; set; }
        public virtual CompartmentWagon CompartmentWagon { get; set; }
        public virtual IEnumerable<Seat> Seats { get; set; }
    }
}