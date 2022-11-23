using ContactsApp.DAL.Interfaces;
using Microsoft.Extensions.Options;

namespace ContactsApp.DAL.JSONFile
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly DatabaseOptions _dbOptions;

        public UnitOfWorkFactory(IOptions<DatabaseOptions> dbOptions)
        {
            _dbOptions = dbOptions.Value;
        }

        public async Task<IUnitOfWork> Create()
        {
            var unitOfWork = new UnitOfWork(_dbOptions.FilePath);
            await unitOfWork.Initialize();

            return unitOfWork;
        }
    }
}
