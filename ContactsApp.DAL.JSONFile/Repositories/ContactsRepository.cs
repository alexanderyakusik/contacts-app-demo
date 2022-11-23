using ContactsApp.DAL.Interfaces.DTO;
using ContactsApp.DAL.Interfaces.Repositories;
using ContactsApp.DAL.JSONFile.IIdentityValueProvider;

namespace ContactsApp.DAL.JSONFile.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly Database _db;
        private readonly ContactsValueProvider _identityValueProvider;

        public ContactsRepository(Database db)
        {
            _db = db;
            _identityValueProvider = new ContactsValueProvider(_db.Contacts, 1, 1);
        }

        public IEnumerable<ContactDTO>? GetAll()
        {
            return _db.Contacts?.ToList();
        }

        public int Create(ContactDTO contact)
        {
            contact.Id = _identityValueProvider.Next();

            _db.Contacts ??= new List<ContactDTO>();
            _db.Contacts.Add(contact);

            return contact.Id;
        }

        public bool Update(ContactDTO contact)
        {
            var dbModel = _db.Contacts?.FirstOrDefault(item => item.Id == contact.Id);
            if (_db.Contacts == null || dbModel == null) return false;

            dbModel.FirstName = contact.FirstName;
            dbModel.LastName = contact.LastName;
            dbModel.Email = contact.Email;

            return true;
        }

        public bool Delete(int id)
        {
            var contact = _db.Contacts?.FirstOrDefault(contact => contact.Id == id);
            if (_db.Contacts == null || contact == null) return false;

            return _db.Contacts.Remove(contact);
        }
    }
}
