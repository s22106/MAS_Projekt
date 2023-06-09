using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class City
    {
        public int CityId { get; set; }
        [StringLength(30)]
        [Required]
        public String Name { get; set; }
        public virtual IEnumerable<TrainStation> TrainStations { get; set; }
    }
}