using AutoMapper;
using Formify.Business.Abstract;
using Formify.Business.Dtos.UserDtos;
using Formify.DataAccess.Repositories.Abstract;
using Formify.Domain.Entities;

namespace Formify.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> ValidateUserAsync(string username, string password)
        {
            var user = await _unitOfWork.Users.GetUserByUsernameAsync(username);
            if (user != null && user.Password == password)
            {
                return _mapper.Map<UserDto>(user);
            }
            return null;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByUsernameAsync(string username)
        {
            var user = await _unitOfWork.Users.GetUserByUsernameAsync(username);
            return _mapper.Map<UserDto>(user);
        }

        public async Task AddUserAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user != null)
            {
                _unitOfWork.Users.Remove(user);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}