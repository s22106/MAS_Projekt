using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.DTOs
{
    public class RailLinkGet
    {
        public int? Id { get; set; }
        public int Length { get; set; }
        public int PlannedTime { get; set; }
        public List<LinkStationGet> TrainStations { get; set; }
    }
}