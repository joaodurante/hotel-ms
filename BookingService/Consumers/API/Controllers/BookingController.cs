using Application.DTOs;
using Application.Ports;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("booking")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingManager _bookingManager;
        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        [HttpGet]
        public async Task<ActionResult<BookingDTO>> Get(int id)
        {
            var res = await _bookingManager.Get(id);

            if (res.Success)
            {
                return Ok(res.Data);
            }

            return NotFound(res);
        }

        [HttpPost]
        public async Task<ActionResult<BookingDTO>> Post(BookingDTO booking)
        {
            var res = await _bookingManager.Post(booking);

            if (res.Success)
            {
                return Created("", res.Data);
            }

            return BadRequest(res);
        }
    }
}
