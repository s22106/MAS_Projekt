using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class ITrainStationService
    {
        private readonly MASDbContext _context;

        public ITrainStationService(MASDbContext context)
        {
            _context = context;
        }
        //change model to dto
        public async Task<List<TrainStation>> GetTrainStations()
        {
            return await _context.TrainStations.ToListAsync();
        }
    }
}