using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.DTOs
{
    public class TrainStationGet
    {
        public string Name { get; set; }
        public int NumberOfPlatforms { get; set; }
        public int NumberOfTracks { get; set; }
    }
}