using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.DTOs;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        public readonly ITransitService _transitService;

        public TicketController(ITransitService transitService)
        {
            _transitService = transitService;
        }

        [HttpPost]
        public async Task<IActionResult> BuyTicket([FromBody] TicketInfoGet ticketInfo, [FromHeader] int passengerId)
        {
            var ticket = await _transitService.BuyTicket(ticketInfo, passengerId);

            return Ok(ticket);
        }
    }
}