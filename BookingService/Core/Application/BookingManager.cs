using Application.DTOs;
using Application.Ports;
using Application.Responses;
using Domain.Exceptions;
using Domain.Ports;

namespace Application
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingManager(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<BookingResponse> Get(int id)
        {
            var booking = await _bookingRepository.Get(id);

            if (booking == null)
            {
                return new BookingResponse
                {
                    Success = false,
                    Error = ErrorCodes.NOT_FOUND,
                    Message = "Booking not found"
                };
            }

            return new BookingResponse
            {
                Success = true,
                Data = BookingDTO.MapToDTO(booking)
            };
        }

        public async Task<BookingResponse> Post(BookingDTO request)
        {
            try
            {
                var booking = BookingDTO.MapToEntity(request);
                request.Id = await booking.Save(_bookingRepository);

                return new BookingResponse
                {
                    Success = true,
                    Data = request
                };
            }
            catch (MissingRequiredFieldsExceptions)
            {
                return new BookingResponse
                {
                    Success = false,
                    Error = ErrorCodes.MISSING_REQUIRED_FIELDS,
                    Message = "Missing required fields"
                };
            }
            catch (Exception)
            {
                return new BookingResponse
                {
                    Success = false,
                    Error = ErrorCodes.COULDNOT_STORE_DATA,
                    Message = "There was an error when saving booking"
                };
            }
        }
    }
}
