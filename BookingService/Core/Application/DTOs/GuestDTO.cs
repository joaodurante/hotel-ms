using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Application.DTOs
{
    public class GuestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string IdNumber { get; set; }
        public int IdTypeCode { get; set; }

        public static Guest MapToEntity(GuestDTO dto)
        {
            return new Guest
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                Document = new PersonId
                {
                    IdNumber = dto.IdNumber,
                    DocumentType = (DocumentType)dto.IdTypeCode
                }
            };
        }
    }
}
