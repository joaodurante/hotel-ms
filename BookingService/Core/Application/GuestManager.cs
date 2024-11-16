using Application.DTOs;
using Application.Ports;
using Application.Requests;
using Application.Responses;
using Domain.Ports;

namespace Application
{
    public class GuestManager : IGuestManager
    {
        private readonly IGuestRepository _guestRepository;
        public GuestManager(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<GuestResponse> Create(CreateGuestRequest request)
        {
            try
            {
                var guest = GuestDTO.MapToEntity(request.Data);
                request.Data.Id = await _guestRepository.Create(guest);

                return new GuestResponse
                {
                    Data = request.Data,
                    Success = true,
                };

            } 
            catch (Exception)
            {
                return new GuestResponse
                {
                    Success = false,
                    Error = ErrorCodes.COULDNOT_STORE_DATA,
                    Message = "There was an error when saving guest"
                };
            }
        }
    }
}
