using ContactsApp.DAL.Interfaces.DTO;

namespace ContactsApp.DAL.JSONFile.IIdentityValueProvider
{
    internal class ContactsValueProvider : BaseIdentityValueProvider
    {
        public ContactsValueProvider(IEnumerable<ContactDTO>? contacts, int startingValue, int increment) : base(startingValue, increment)
        {
            if (contacts == null || !contacts.Any()) return;

            var currentValue = contacts.Max(contact => contact.Id);
            SetValue(currentValue);
        }
    }
}
