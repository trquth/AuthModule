using Auth.Core.Interfaces.Repositories;
using Auth.Entities;

namespace Auth.Repositories
{
    public class UsersRepository : BaseRepository<Users>, IUsersRepository
    {
        private AuthContext _context = null;

        public UsersRepository(AuthContext context)
        {
            _context = context;
        }
    }
}
