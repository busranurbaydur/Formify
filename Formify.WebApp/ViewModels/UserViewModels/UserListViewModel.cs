using Formify.Business.Dtos.UserDtos;

namespace Formify.WebApp.ViewModels.UserViewModels
{
    public class UserListViewModel
    {
        public IEnumerable<UserDto> Users { get; set; }
    }
}