using WDD.Data.Entities;
using WDD.Data.Repositories.Abstract;

namespace WDD.Data.Repositories.Concrete
{
    public class ContactsRepository : IContactsRepository
    {

        private readonly AppDbContext _context;

        public ContactsRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Contact> GetContactsByLastName(string lastName)
        {
            return _context.Contacts.Where(c => c.LastName.Contains(lastName));
        }

    }
}
