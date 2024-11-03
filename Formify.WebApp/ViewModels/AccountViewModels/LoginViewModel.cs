using System.ComponentModel.DataAnnotations;

namespace Formify.WebApp.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur. ")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur. ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}