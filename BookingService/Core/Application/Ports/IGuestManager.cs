using Application.Requests;
using Application.Responses;

namespace Application.Ports
{
    public interface IGuestManager
    {
        Task<GuestResponse> Create(CreateGuestRequest resquest);
    }
}
