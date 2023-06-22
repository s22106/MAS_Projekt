using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public abstract class Wagon
    {
        public int WagonId { get; set; }
        [Required]
        public int TrainId { get; set; }
        [Required]
        public int Class { get; set; }
        public int NumberOfSeats
        {
            get
            {
                if (Class == 1)
                    return 40;
                else
                    return 80;
            }
        }
        public bool? IsSeatRequired { get; set; }
        [Required]
        public int WagonNumber { get; set; }
        public virtual OpenWagon? OpenWagon { get; set; }
        public virtual CompartmentWagon? CompartmentWagon { get; set; }
        public virtual Train Train { get; set; }
        public virtual IEnumerable<Seat> Seats { get; set; }
    }
}