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
    public class TransitService : ITransitService
    {
        private readonly MASDbContext _context;

        public TransitService(MASDbContext context)
        {
            _context = context;
        }

        public async Task<List<TransitsGet>> GetTransitsByDay(DateTime date, List<int> linkId)
        {
            return await _context.RailLinks.Include(e => e.Transits)
                .Include(e => e.LinkStations).ThenInclude(e => e.Station)
                .Where(x => x.Transits.Any(y => y.Date == date.Date))
                .Where(x => x.LinkStations.Any(y => linkId.Contains(y.LinkId)))
                .Select(e => new TransitsGet
                {
                    Length = e.Length,
                    PlannedTime = e.PlannedTime,
                    TrainStations = e.LinkStations.Select(e => new LinkStationGet
                    {
                        Number = e.Number,
                        Name = e.Station.Name,
                        DepartureTime = e.DepartureTime,
                        ArrivalTime = e.ArrivalTime,
                        Type = e.Type
                    }).ToList(),
                    Date = date
                }).ToListAsync();
        }
    }
}