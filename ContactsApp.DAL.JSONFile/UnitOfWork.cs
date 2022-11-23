using ContactsApp.DAL.Interfaces;
using ContactsApp.DAL.Interfaces.Repositories;
using ContactsApp.DAL.JSONFile.Repositories;
using Newtonsoft.Json;

namespace ContactsApp.DAL.JSONFile
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _filePath;

        private Database? _db;

        private IContactsRepository? _contactsRepository;

        public UnitOfWork(string? filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath)) throw new FileNotFoundException("Error when trying to create a Unit of Work instance. Database file does not exist.", filePath);

            _filePath = filePath;
        }

        public IContactsRepository ContactsRepository => _contactsRepository ?? (_contactsRepository = new ContactsRepository(_db!));

        public async Task Initialize()
        {
            using var fileStream = new FileStream(_filePath, FileMode.Open);
            using var streamReader = new StreamReader(fileStream);
            var content = await streamReader.ReadToEndAsync();

            _db = JsonConvert.DeserializeObject<Database>(content) ?? new Database();
        }

        public async Task CommitAsync()
        {
            var json = JsonConvert.SerializeObject(_db);
            
            using var fileStream = new FileStream(_filePath, FileMode.Truncate);
            using var streamWriter = new StreamWriter(fileStream);
            await streamWriter.WriteAsync(json);
        }
    }
}
