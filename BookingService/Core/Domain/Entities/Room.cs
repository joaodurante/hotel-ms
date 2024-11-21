using Domain.Enums;
using Domain.Exceptions;
using Domain.Ports;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool InMaintenance { get; set; }
        public Price Price { get; set; }
        public ICollection<Booking> Bookings { get; set; }

        public bool HasGuest
        {
            get
            {
                var unavailableStatuses = new List<EStatus>()
                {
                    EStatus.Created,
                    EStatus.Paid
                };

                return this.Bookings.Where(
                    b => b.Room.Id == this.Id && unavailableStatuses.Contains(b.Status)
                ).Count() > 0;
            }
        }
        public bool isAvailable
        {
            get
            {
                if (this.HasGuest || this.InMaintenance) { return false; }
                return true;
            }
        }

        private void ValidateState()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new MissingRequiredFieldsExceptions();
            }
        }

        public async Task<int> Save(IRoomRepository roomRepository)
        {
            this.ValidateState();

            if (this.Id == 0)
            {
                return await roomRepository.Create(this);
            }
            else
            {
                return await roomRepository.Update(this);
            }
        }

        public bool CanBeBooked()
        {
            try
            {
                this.ValidateState();
            }
            catch (Exception)
            {
                return false;
            }

            if (!this.isAvailable)
            {
                return false;
            }

            return true;
        }
    }
}
