using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class RailLink
    {
        public int LinkId { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public int PlannedTime { get; set; }
        public virtual IEnumerable<LinkStations> LinkStations { get; set; }
        public virtual IEnumerable<Transit> Transits { get; set; }
    }
}