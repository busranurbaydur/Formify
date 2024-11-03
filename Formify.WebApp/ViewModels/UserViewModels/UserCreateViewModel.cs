using Formify.Business.Dtos.UserDtos;
using System.ComponentModel.DataAnnotations;

namespace Formify.WebApp.ViewModels.UserViewModels
{
    public class UserCreateViewModel
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public CreateUserDto ToDto()
        {
            return new CreateUserDto
            {
                Username = this.Username,
                Password = this.Password
            };
        }
    }
}