using WDD.Data.Entities;

namespace WDD.Data.Repositories.Abstract
{
    public interface IContactsRepository
    {
        IEnumerable<Contact> GetContactsByLastName(string lastName);
    }
}
