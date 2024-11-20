using Domain.Entities;

namespace Domain.Ports
{
    public interface IBookingRepository
    {
        public Task<Booking> Get(int id);
        public Task<List<Booking>> GetAll();
        public Task<int> Create(Booking booking);
        public Task<int> Update(Booking booking);
        public Task Delete(int id);
    }
}
