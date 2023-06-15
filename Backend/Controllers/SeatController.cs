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
    public class SeatController : ControllerBase
    {
        public readonly ITransitService _transitService;
        public SeatController(ITransitService transitService)
        {
            _transitService = transitService;
        }

        [HttpGet("{trainId}")]
        public async Task<IActionResult> GetFreeSeats(int trainId)
        {
            var freeSeats = await _transitService.GetFreeSeats(trainId);

            return Ok(freeSeats);
        }
    }
}