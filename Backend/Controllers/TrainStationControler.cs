using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Services;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainStationControler : ControllerBase
    {
        private readonly ITrainStationService _trainStationSerice;

        public TrainStationControler(ITrainStationService trainStationService)
        {
            _trainStationSerice = trainStationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrainStations()
        {
            var trainStations = await _trainStationSerice.GetTrainStations();

            return Ok(trainStations);
        }
    }
}