using Application.DTOs;
using Application.Responses;

namespace Application.Ports
{
    public interface IGuestManager
    {
        Task<GuestResponse> Create(GuestDTO guest);
    }
}
