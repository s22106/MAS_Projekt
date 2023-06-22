using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using API.Models;
using Backend.Models.DTOs;
using Backend.Models.Enum;
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

        public async Task<TicketGet> BuyTicket(TicketInfoGet ticketInfo, int passengerId)
        {
            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var person = await _context.Persons
                .Where(e => e.PersonId == passengerId)
                .FirstOrDefaultAsync();
            SeatType seatType = await _context.Seats
                .Where(e => e.WagonNumber == ticketInfo.wagonNumber && e.SeatNumber == ticketInfo.seatNumber)
                .Select(e => e.Type)
                .FirstOrDefaultAsync();
            string format = "HH:mm:ss";
            DateTime.TryParseExact(ticketInfo.date, format, null, System.Globalization.DateTimeStyles.None, out DateTime dateTime);
            dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
            var entity = await _context.Set<Ticket>()
                .AddAsync(new Ticket
                {
                    TransitId = 1,
                    Seat = ticketInfo.seatNumber,
                    Wagon = ticketInfo.wagonNumber,
                    PassengerId = passengerId,
                    Price = 19.99m,
                    DepartureTime = dateTime,
                    SeatType = seatType,
                });
            await _context.SaveChangesAsync();
            transaction.Complete();

            return new TicketGet
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Price = entity.Entity.Price,
                SeatNumber = entity.Entity.Seat,
                WagonNumber = entity.Entity.Wagon,
                DepartureTime = entity.Entity.DepartureTime,
                StartStation = ticketInfo.startStation,
                EndStation = ticketInfo.endStation,
                SeatType = entity.Entity.SeatType,
            };
        }

        public async Task<List<SeatGet>> GetFreeSeats(int transitId)
        {
            //Bad if different trains on different dates 
            var trainId = await _context.Transits
                .Where(e => e.TransitId == transitId)
                .Select(e => e.TransitId)
                .FirstOrDefaultAsync();
            var AllSeats = await _context.Seats
                .Include(e => e.Wagon)
                .Where(e => e.Wagon.TrainId == trainId)
                .Distinct()
                .Select(e => new SeatGet
                {
                    WagonNumber = e.Wagon.WagonNumber,
                    SeatNumber = e.SeatNumber
                })
                .ToListAsync();
            var SeatsTaken = await _context.Tickets
                .Where(e => e.TransitId == transitId)
                .Distinct()
                .Select(e => new SeatGet
                {
                    WagonNumber = e.Wagon,
                    SeatNumber = e.Seat
                })
                .ToListAsync();

            var SeatsLeft = AllSeats.Where(e => !SeatsTaken.Any(x => x.WagonNumber == e.WagonNumber && x.SeatNumber == e.SeatNumber)).ToList();

            return SeatsLeft;
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