using ContactsApp.DAL.Interfaces.DTO;
using ContactsApp.Domain.Models;

namespace ContactsApp.Domain.Mapping
{
    internal static class ContactMappingExtensions
    {
        internal static Contact ToModel(this ContactDTO dto) => new()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
        };

        internal static ContactDTO ToDTO(this Contact model) => new()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
        };
    }
}
