using Domain.Entities;
using Domain.Ports;

namespace Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private HotelDbContext hotelDbContext;
        public RoomRepository(HotelDbContext hotelDbContext)
        {
            this.hotelDbContext = hotelDbContext;
        }
        public async Task<Room> Get(int id)
        {
            return await hotelDbContext.Rooms.FindAsync(id);
        }

        public async Task<int> Create(Room room)
        {
            hotelDbContext.Rooms.Add(room);
            await hotelDbContext.SaveChangesAsync();
            return room.Id;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Task<List<Room>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
