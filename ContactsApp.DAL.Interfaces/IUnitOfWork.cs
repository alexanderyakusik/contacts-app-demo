using ContactsApp.DAL.Interfaces.Repositories;

namespace ContactsApp.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IContactsRepository ContactsRepository { get; }



        Task CommitAsync();
    }
}