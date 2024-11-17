using Domain.Entities;
using Domain.Ports;

namespace Data.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private HotelDbContext hotelDbContext;
        public GuestRepository(HotelDbContext hotelDbContext)
        {
            this.hotelDbContext = hotelDbContext;
        }

        public async Task<int> Create(Guest guest)
        {
            hotelDbContext.Guests.Add(guest);
            await hotelDbContext.SaveChangesAsync();
            return guest.Id;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Guest> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Guest>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Guest guest)
        {
            throw new NotImplementedException();
        }
    }
}
