using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Models.Enum;

namespace API.Models
{
    public class LinkStations
    {
        public int LinkId { get; set; }
        public int StationId { get; set; }
        [Required]
        public int Number { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        [EnumDataType(typeof(LinkStations))]
        public StationType? Type { get; set; }
        public virtual RailLink Link { get; set; }
        public virtual TrainStation Station { get; set; }
    }
}