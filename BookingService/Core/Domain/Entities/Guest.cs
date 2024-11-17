using Domain.Exceptions;
using Domain.Ports;
using Domain.Utils;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public PersonId Document { get; set; }

        private void ValidateState()
        {
            if(Name == null || Surname == null ||  Email == null)
            {
                throw new MissingRequiredFieldsExceptions();
            }

            if (!UtilsTools.ValidateEmail(Email))
            {
                throw new InvalidPersonEmail();
            }

            if(Document == null ||
                Document.IdNumber.Length < 3 ||
                Document.DocumentType < 0)
            {
                throw new InvalidPersonDocumentException();
            }
        }

        public async Task<int> Save(IGuestRepository guestRepository)
        {
            this.ValidateState();

            if(this.Id == 0)
            {
                return await guestRepository.Create(this);
            }
            else
            {
                return await guestRepository.Update(this);
            }
        }
    }
}
