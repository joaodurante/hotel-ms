using Domain.Entities;

namespace Domain.Ports
{
    public interface IRoomRepository
    {
        public Task<Room> Get(int id);
        public Task<List<Room>> GetAll();
        public Task<int> Create(Room room);
        public Task<int> Update(Room room);
        public Task Delete(int id);
    }
}
