using Application.DTOs;
using Application.Ports;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("room")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoomManager _roomManager;

        public RoomController(ILogger<RoomController> logger, IRoomManager roomManager)
        {
            _logger = logger;
            _roomManager = roomManager;
        }

        [HttpGet]
        public async Task<ActionResult<RoomDTO>> Get(int id)
        {
            var res = await _roomManager.Get(id);

            if (res.Success)
            {
                return Ok(res.Data);
            }

            return NotFound(res);
        }

        [HttpPost]
        public async Task<ActionResult<RoomDTO>> Create(RoomDTO request)
        {
            var res = await _roomManager.Create(request);

            if (res.Success)
            {
                return Created("", res.Data);
            }

            switch (res.Error)
            {
                case ErrorCodes.NOT_FOUND:
                case ErrorCodes.MISSING_REQUIRED_FIELDS:
                    return BadRequest(res);
            }

            _logger.LogError("Response with unknown ErrorCode returned", res);
            return BadRequest(500);

        }
    }
}
