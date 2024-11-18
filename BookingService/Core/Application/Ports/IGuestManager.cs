using Application.DTOs;
using Application.Responses;

namespace Application.Ports
{
    public interface IGuestManager
    {
        Task<GuestResponse> Get(int id);
        Task<GuestResponse> Create(GuestDTO guest);
    }
}
