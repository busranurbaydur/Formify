using Formify.DataAccess.Context;
using Formify.DataAccess.Repositories.Abstract;
using Formify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Formify.DataAccess.Repositories.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}