using ContactsApp.DAL.Interfaces.DTO;

namespace ContactsApp.DAL.Interfaces.Repositories
{
    public interface IContactsRepository
    {
        IEnumerable<ContactDTO>? GetAll();

        int Create(ContactDTO contact);

        bool Update(ContactDTO contact);

        bool Delete(int id);
    }
}
