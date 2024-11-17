using Domain.Entities;

namespace Domain.Ports
{
    public interface IGuestRepository
    {
        public Task<Guest> Get(int id);
        public Task<List<Guest>> GetAll();
        public Task<int> Create(Guest guest);
        public Task<int> Update(Guest guest);
        public Task Delete(int id);
    }
}
