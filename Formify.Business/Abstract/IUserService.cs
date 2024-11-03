using Formify.Business.Dtos.UserDtos;

namespace Formify.Business.Abstract
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        Task<UserDto> GetUserByIdAsync(int id);

        Task<UserDto> GetUserByUsernameAsync(string username);

        Task AddUserAsync(CreateUserDto createUserDto);

        Task UpdateUserAsync(UserDto userDto);

        Task DeleteUserAsync(int id);

        Task<UserDto> ValidateUserAsync(string username, string password);
    }
}