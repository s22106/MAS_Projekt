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

        public async Task<Dictionary<int, KeyValuePair<int, int>>> GetFreeSeats(int transitId)
        {
            //Bad if different trains on different dates 
            //TODO: Better check for trains
            var trainId = await _context.Transits
                .Where(e => e.TransitId == transitId)
                .Select(e => e.TransitId)
                .FirstOrDefaultAsync();
            var AllSeats = await _context.Seats
                .Where(e => e.Wagon.TrainId == trainId)
                .Distinct()
                .ToDictionaryAsync(x => x.SeatId, y => new KeyValuePair<int, int>(y.WagonNumber, y.SeatNumber));
            var SeatsTaken = await _context.Tickets
                .Where(e => e.TransitId == transitId)
                .ToDictionaryAsync(x => x.TicketId, y => new KeyValuePair<int, int>(y.Wagon, y.Seat));

            var SeatsToRemove = SeatsTaken.Values.ToList();

            foreach (var seat in SeatsToRemove)
            {
                var seatToRemove = AllSeats.FirstOrDefault(kvp => kvp.Value.Equals(seat));
                if (!Equals(seatToRemove, default(KeyValuePair<int, KeyValuePair<int, int>>)))
                {
                    AllSeats.Remove(seatToRemove.Key);
                }
            }

            return AllSeats;
        }

        public async Task<TransitsGet> GetTransitById(int id)
        {
            return await _context.RailLinks.Include(e => e.Transits)
                .Include(e => e.LinkStations).ThenInclude(e => e.Station)
            .Where(x => x.Transits.Any(y => y.TransitId == id))
            .Select(e => new TransitsGet
            {
                Id = e.Transits.Select(x => x.TransitId).SingleOrDefault(),
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
                Date = e.Transits.Select(x => x.Date).SingleOrDefault()
            }).SingleOrDefaultAsync();
        }

        public async Task<List<TransitsGet>> GetTransitsByDay(DateTime date, List<int> linkId)
        {
            return await _context.RailLinks.Include(e => e.Transits)
                .Include(e => e.LinkStations).ThenInclude(e => e.Station)
                .Where(x => x.Transits.Any(y => y.Date == date.Date))
                .Where(x => x.LinkStations.Any(y => linkId.Contains(y.LinkId)))
                .Select(e => new TransitsGet
                {
                    Id = e.Transits.Select(x => x.TransitId).SingleOrDefault(),
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