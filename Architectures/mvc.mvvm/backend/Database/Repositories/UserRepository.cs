using backend.Database.Interfaces;
using backend.Models;

namespace backend.Database.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context) : base(context) 
            => _context = context;       
    }
}