using Domain.Entities;
using Domain.Ports;

namespace Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public BookingRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public async Task<Booking> Get(int id)
        {
            return await _hotelDbContext.Bookings.FindAsync(id);
        }
        public async Task<int> Create(Booking booking)
        {
            _hotelDbContext.Add(booking);
            await _hotelDbContext.SaveChangesAsync();
            return booking.Id;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
