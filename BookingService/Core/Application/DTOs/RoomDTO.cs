using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Application.DTOs
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool InMaintenance { get; set; }
        public decimal Price { get; set; }
        public AcceptedCurrencies Currency { get; set; }
        public bool HasGuest { get; set; }
        public bool IsAvailable { get; set; }

        public static Room MapToEntity(RoomDTO roomDTO)
        {
            return new Room
            {
                Id = roomDTO.Id,
                Name = roomDTO.Name,
                Level = roomDTO.Level,
                InMaintenance = roomDTO.InMaintenance,
                Price = new Price
                {
                    Value = roomDTO.Price,
                    Currency = roomDTO.Currency
                }
            };
        }

        public static RoomDTO MapToDTO(Room room)
        {
            return new RoomDTO
            {
                Id = room.Id,
                Name = room.Name,
                Level = room.Level,
                InMaintenance = room.InMaintenance,
                Price = room.Price.Value,
                Currency = room.Price.Currency,
                HasGuest = room.HasGuest,
                IsAvailable = room.isAvailable
            };
        }
    }
}
