using Domain.Entities;
using Domain.Enums;

namespace Application.DTOs
{
    public class BookingDTO
    {
        public BookingDTO()
        {
            this.PlacedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime PlacedAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public EStatus Status { get; set; }
        public int GuestId { get; set; }
        public int RoomId { get; set; }

        public static Booking MapToEntity(BookingDTO bookingDTO)
        {
            return new Booking
            {
                Id = bookingDTO.Id,
                PlacedAt = bookingDTO.PlacedAt,
                Start = bookingDTO.Start,
                End = bookingDTO.End,
                Guest = new Guest { Id = bookingDTO.GuestId },
                Room = new Room { Id = bookingDTO.RoomId },
            };
        }

        public static BookingDTO MapToDTO(Booking booking)
        {
            return new BookingDTO
            {
                Id = booking.Id,
                Start = booking.Start,
                End = booking.End,
                GuestId = booking.Guest.Id,
                RoomId = booking.Room.Id
            };
        }
    }
}
