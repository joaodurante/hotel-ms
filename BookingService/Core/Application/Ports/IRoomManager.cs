using Application.DTOs;
using Application.Responses;

namespace Application.Ports
{
    public interface IRoomManager
    {
        public Task<RoomResponse> Get(int id);
        public Task<RoomResponse> Create(RoomDTO roomDTO);
    }
}
