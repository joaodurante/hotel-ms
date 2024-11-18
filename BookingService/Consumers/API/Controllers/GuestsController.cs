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

        [HttpGet]
        public async Task<ActionResult<GuestDTO>> Get(int id)
        {
            var res = await _guestManager.Get(id);
            if (res.Success)
            {
                return Ok(res.Data);
            }

            return NotFound(res);
        }

        [HttpPost]
        public async Task<ActionResult<GuestDTO>> Create(GuestDTO guest)
        {
            var res = await _guestManager.Create(guest);

            if (res.Success) return Created("", res.Data);

            switch (res.Error)
            {
                case ErrorCodes.NOT_FOUND:
                case ErrorCodes.INVALID_PERSON_EMAIL:
                case ErrorCodes.INVALID_PERSON_DOCUMENT:
                case ErrorCodes.MISSING_REQUIRED_FIELDS:
                    return BadRequest(res);
            }

            _logger.LogError("Response with unknown ErrorCode returned", res);
            return BadRequest(500);
        }
    }
}
