using BlogEngine.Data.Infrastrutures;
using BlogEngine.Data.Repositories.IRepositories;
using BlogEngine.Model.Models;
using BlogEngine.Service.IServices;

namespace BlogEngine.Service
{
    public class ContactService : IContactService
    {
        private IUnitOfWork _unitOfWork;
        private IContactRepository _contactRepository;

        public ContactService(
            IUnitOfWork unitOfWork,
            IContactRepository contactRepository)
        {
            this._unitOfWork = unitOfWork;
            this._contactRepository = contactRepository;
        }

        public Contact AddContact(Contact contact)
        {
            return _contactRepository.Add(contact);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
