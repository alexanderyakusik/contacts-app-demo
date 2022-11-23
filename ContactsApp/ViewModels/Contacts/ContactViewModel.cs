using ContactsApp.Domain.Models;

namespace ContactsApp.Requests.Contacts
{
    public class ContactViewModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public Contact ToModel() => new()
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
        };
    }
}
