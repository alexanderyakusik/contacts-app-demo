using ContactsApp.DAL.Interfaces;
using ContactsApp.Domain.Mapping;
using ContactsApp.Domain.Models;

namespace ContactsApp.Domain.Services
{
    public class ContactsService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ContactsService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<IEnumerable<Contact>?> GetAll()
        {
            var unitOfWork = await _unitOfWorkFactory.Create();

            var contacts = unitOfWork.ContactsRepository.GetAll();

            return contacts?.Select(contact => contact.ToModel());
        }
        
        public async Task<int> Create(Contact contact)
        {
            var unitOfWork = await _unitOfWorkFactory.Create();

            var result = unitOfWork.ContactsRepository.Create(contact.ToDTO());
            await unitOfWork.CommitAsync();

            return result;
        }

        public async Task<bool> Update(Contact contact)
        {
            var unitOfWork = await _unitOfWorkFactory.Create();

            var result = unitOfWork.ContactsRepository.Update(contact.ToDTO());
            if (!result) return result;

            await unitOfWork.CommitAsync();

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var unitOfWork = await _unitOfWorkFactory.Create();

            var result = unitOfWork.ContactsRepository.Delete(id);
            if (!result) return result;

            await unitOfWork.CommitAsync();

            return result;
        }
    }
}
