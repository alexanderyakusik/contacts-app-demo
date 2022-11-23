namespace ContactsApp.DAL.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        Task<IUnitOfWork> Create();
    }
}
