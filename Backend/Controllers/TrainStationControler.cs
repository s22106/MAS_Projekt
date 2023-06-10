using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainStationControler : ControllerBase
    {
        private readonly ITrainStationService _trainStationSerive;

        public TrainStationControler(ITrainStationService trainStationService)
        {
            _trainStationSerive = trainStationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrainStations()
        {
            var trainStations = await _trainStationSerive.GetTrainStations();

            return Ok(trainStations);
        }
    }
}