using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Enum;

namespace API.Models
{
    public class TrainStation
    {
        public int StationId { get; set; }
        public int CityId { get; set; }
        public int NumbrOfPlatforms { get; set; }
        public int NumbrOfTracks { get; set; }
        public string Name { get; set; }
        public StationType? StationType { get; set; }
        public virtual City City { get; set; }
        public virtual IEnumerable<LinkStations> LinkStations { get; set; }
    }
}