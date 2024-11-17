using Application.DTOs;
using Application.Ports;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("guests")]
    public class GuestsController : ControllerBase
    {
        private readonly ILogger<GuestsController> _logger;
        private readonly IGuestManager _guestManager;

        public GuestsController(
            ILogger<GuestsController> logger,
            IGuestManager ports) 
        {
            _logger = logger;
            _guestManager = ports;
        }

        [HttpPost]
        public async Task<ActionResult<GuestDTO>> Create(GuestDTO guest)
        {
            var res = await _guestManager.Create(guest);

            if (res.Success) return Created("", res.Data);

            if (res.Error == ErrorCodes.NOT_FOUND) return BadRequest(res);

            _logger.LogError("Response with unknown ErrorCode returned", res);
            return BadRequest(500);
        }
    }
}
