using Domain.Enums;
using Domain.Exceptions;
using Domain.Ports;
using Action = Domain.Enums.Action;

namespace Domain.Entities
{
    public class Booking
    {
        public Booking()
        {
            this.Status = EStatus.Created;
        }

        public int Id { get; set; }
        public DateTime PlacedAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public EStatus Status { get; set; }
        public Guest Guest { get; set; }
        public Room Room { get; set; }

        public void ChangeState(Action action)
        {
            this.Status = (this.Status, action) switch
            {
                (EStatus.Created, Action.Pay) => EStatus.Paid,
                (EStatus.Created, Action.Cancel) => EStatus.Canceled,
                (EStatus.Paid, Action.Finish) => EStatus.Finished,
                (EStatus.Paid, Action.Refound) => EStatus.Refounded,
                (EStatus.Canceled, Action.Reopen) => EStatus.Created,
                _ => Status
            };
        }

        private void ValidateState()
        {
            if (this.PlacedAt == default(DateTime) || this.Start == default(DateTime) || this.End == default(DateTime) || this.Room == null || this.Guest == null)
            {
                throw new MissingRequiredFieldsExceptions();
            }
        }

        public async Task<int> Save(IBookingRepository _bookingRepository)
        {
            this.ValidateState();
            this.Guest.ValidateState();
            if (!this.Room.CanBeBooked())
            {
                throw new RoomCannotBeBookedException();
            }

            if (this.Id == 0)
            {
                return await _bookingRepository.Create(this);
            }

            return await _bookingRepository.Update(this);
        }
    }
}
