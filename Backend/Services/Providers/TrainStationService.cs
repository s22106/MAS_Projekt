using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Backend.Models.DTOs;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Providers
{
    public class TrainStationService : ITrainStationService
    {
        private readonly MASDbContext _context;

        public TrainStationService(MASDbContext context)
        {
            _context = context;
        }

        public async Task<List<RailLinkGet>> GetRailLinks()
        {
            return await _context.RailLinks.Include(e => e.LinkStations)
                .Select(x => new RailLinkGet
                {
                    Length = x.Length,
                    PlannedTime = x.PlannedTime,
                    TrainStations = x.LinkStations.Select(y => new LinkStationGet
                    {
                        Number = y.Number,
                        DepartureTime = y.DepartureTime,
                        ArrivalTime = y.ArrivalTime,
                        Type = y.Type,
                        Name = y.Station.Name
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<List<TrainStationGet>> GetTrainStations()
        {
            return await _context.TrainStations.Select(x => new TrainStationGet
            {
                Name = x.Name,
                NumberOfPlatforms = x.NumberOfPlatforms,
                NumberOfTracks = x.NumberOfTracks
            }).ToListAsync();
        }


        public async Task<List<int>> SearchRailLinks(string StartStation, string EndStation)
        {
            return await _context.RailLinks.Include(e => e.LinkStations)
                .ThenInclude(e => e.Station)
                .Where(e => e.LinkStations.Single(e => e.Station.Name == StartStation).Number < e.LinkStations.Single(e => e.Station.Name == EndStation).Number)
                .Select(x => x.LinkId)
                .ToListAsync();
        }
    }
}