using Formify.Domain.Entities;

namespace Formify.DataAccess.Repositories.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}