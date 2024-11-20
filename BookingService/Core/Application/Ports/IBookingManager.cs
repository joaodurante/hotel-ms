using Application.DTOs;
using Application.Responses;

namespace Application.Ports
{
    public interface IBookingManager
    {
        public Task<BookingResponse> Get(int id);
        public Task<BookingResponse> Post(BookingDTO booking);
    }
}
