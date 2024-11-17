using Application.DTOs;
using Application.Ports;
using Application.Responses;
using Domain.Exceptions;
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
                request.Id = await guest.Save(_guestRepository);

                return new GuestResponse
                {
                    Data = request,
                    Success = true,
                };

            } 
            catch(MissingRequiredFieldsExceptions)
            {
                return new GuestResponse
                {
                    Success = false,
                    Error = ErrorCodes.MISSING_REQUIRED_FIELDS,
                    Message = "Missing required fields"
                };
            }
            catch(InvalidPersonEmail)
            {
                return new GuestResponse
                {
                    Success = false,
                    Error = ErrorCodes.INVALID_PERSON_EMAIL,
                    Message = "The informed email is not valid"
                };
            } 
            catch(InvalidPersonDocumentException)
            {
                return new GuestResponse
                {
                    Success = false,
                    Error = ErrorCodes.INVALID_PERSON_DOCUMENT,
                    Message = "The informed document is not valid"
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
