using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Enum;

namespace API.Models
{
    public class TrainStation
    {
        public int StationId { get; set; }
        public int CityId { get; set; }
        [Required]
        public int NumberOfPlatforms { get; set; }
        [Required]
        public int NumberOfTracks { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual City City { get; set; }
        public virtual IEnumerable<LinkStations> LinkStations { get; set; }
    }
}