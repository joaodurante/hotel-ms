﻿using Domain.Entities;
using Domain.Ports;

namespace Data.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelDbContext _hotelDbContext;
        public GuestRepository(HotelDbContext hotelDbContext)
        {
            this._hotelDbContext = hotelDbContext;
        }

        public async Task<Guest> Get(int id)
        {
            return await _hotelDbContext.Guests.FindAsync(id);
        }

        public async Task<int> Create(Guest guest)
        {
            _hotelDbContext.Guests.Add(guest);
            await _hotelDbContext.SaveChangesAsync();
            return guest.Id;
        }

        public Task Delete(int id)
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
