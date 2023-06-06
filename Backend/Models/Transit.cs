using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Transit
    {
        public int transitId { get; set; }
        public int LinkId { get; set; }
        public int TrainId { get; set; }
        public DateTime Date { get; set; }
        public int delay { get; set; }
        public String state { get; set; }
        public virtual RailLink Link { get; set; }
        public virtual Train Train { get; set; }
        public virtual IEnumerable<Ticket> Tickets { get; set; }
    }
}