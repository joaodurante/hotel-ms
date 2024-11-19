using Application.DTOs;
using Application.Ports;
using Application.Responses;
using Domain.Ports;

namespace Application
{
    public class RoomManager : IRoomManager
    {
        private readonly IRoomRepository _roomRepository;

        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<RoomResponse> Get(int id)
        {
            var room = await _roomRepository.Get(id);

            if (room == null)
            {
                return new RoomResponse
                {
                    Success = false,
                    Error = ErrorCodes.NOT_FOUND,
                    Message = "Room not found"
                };
            }

            return new RoomResponse
            {
                Success = true,
                Data = RoomDTO.MapToDTO(room)
            };
        }

        public async Task<RoomResponse> Create(RoomDTO request)
        {
            try
            {
                var room = RoomDTO.MapToEntity(request);
                request.Id = await room.Save(_roomRepository);

                return new RoomResponse
                {
                    Success = true,
                    Data = request
                };
            }
            catch (Exception)
            {
                return new RoomResponse
                {
                    Success = false,
                    Error = ErrorCodes.COULDNOT_STORE_DATA,
                    Message = "There was an error when saving room"
                };
            }
        }
    }
}
