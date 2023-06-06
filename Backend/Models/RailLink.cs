using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class RailLink
    {
        public int LinkId { get; set; }
        public int? lenght { get; set; }
        public virtual IEnumerable<LinkStations> LinkStations { get; set; }
        public virtual IEnumerable<Transit> Transits { get; set; }
    }
}