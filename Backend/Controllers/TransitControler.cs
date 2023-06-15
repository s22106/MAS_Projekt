using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransitControler : ControllerBase
    {
        public readonly ITrainStationService _trainStationService;
        public readonly ITransitService _transitService;

        public TransitControler(ITrainStationService trainStationService, ITransitService transitService)
        {
            _trainStationService = trainStationService;
            _transitService = transitService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransits([FromQuery] string startStation, [FromQuery] string endStation, [FromQuery] DateTime date)
        {
            var railLinkIDs = await _trainStationService.SearchRailLinks(startStation, endStation);
            var transitsByDay = await _transitService.GetTransitsByDay(date, railLinkIDs);

            return Ok(transitsByDay);
        }
        [HttpGet("{transitId}")]
        public async Task<IActionResult> GetTransitById(int transitId)
        {
            var transit = await _transitService.GetTransitById(transitId);

            return Ok(transit);
        }
    }
}