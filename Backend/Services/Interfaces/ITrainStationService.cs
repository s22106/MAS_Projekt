using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Backend.Models.DTOs;

namespace Backend.Services.Interfaces
{
    public interface ITrainStationService
    {
        public Task<List<TrainStationGet>> GetTrainStations();
        public Task<List<RailLinkGet>> GetRailLinks();
        public Task<List<int>> SearchRailLinks(string StartStation, string EndStation);
    }
}