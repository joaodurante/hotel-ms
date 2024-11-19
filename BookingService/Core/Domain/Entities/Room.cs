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
        public bool HasGuest
        {
            get
            {
                return true;
            }
        }
        public bool isAvailable
        {
            get
            {
                if (this.HasGuest || this.InMaintenance) { return true; }
                return false;
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
    }
}
