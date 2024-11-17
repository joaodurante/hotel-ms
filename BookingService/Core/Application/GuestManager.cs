using Application.DTOs;
using Application.Ports;
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

        public async Task<GuestResponse> Create(GuestDTO request)
        {
            try
            {
                var guest = GuestDTO.MapToEntity(request);
                request.Id = await _guestRepository.Create(guest);

                return new GuestResponse
                {
                    Data = request,
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
