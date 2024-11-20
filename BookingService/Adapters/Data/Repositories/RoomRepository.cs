﻿using Domain.Entities;
using Domain.Ports;

namespace Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _hotelDbContext;
        public RoomRepository(HotelDbContext hotelDbContext)
        {
            this._hotelDbContext = hotelDbContext;
        }
        public async Task<Room> Get(int id)
        {
            return await _hotelDbContext.Rooms.FindAsync(id);
        }

        public async Task<int> Create(Room room)
        {
            _hotelDbContext.Rooms.Add(room);
            await _hotelDbContext.SaveChangesAsync();
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
