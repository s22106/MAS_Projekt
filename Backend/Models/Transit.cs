using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Enum;

namespace API.Models
{
    public class Transit
    {
        public int TransitId { get; set; }
        [Required]
        public int LinkId { get; set; }
        [Required]
        public int TrainId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int delay { get; set; }
        [Required]
        [EnumDataType(typeof(TransitState))]
        public TransitState state { get; set; }
        public virtual RailLink Link { get; set; }
        public virtual Train Train { get; set; }
        public virtual IEnumerable<Ticket> Tickets { get; set; }
    }
}