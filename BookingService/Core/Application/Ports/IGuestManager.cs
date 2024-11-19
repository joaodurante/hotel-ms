using Application.DTOs;
using Application.Responses;

namespace Application.Ports
{
    public interface IGuestManager
    {
        Task<GuestResponse> Get(int Id);
        Task<GuestResponse> Create(GuestDTO guest);
    }
}
