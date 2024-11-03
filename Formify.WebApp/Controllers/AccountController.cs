using Formify.Business.Abstract;
using Formify.Business.Dtos.UserDtos;
using Formify.WebApp.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Formify.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserByUsernameAsync(viewModel.Username);

                if (user != null && user.Password == viewModel.Password)
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("UserId", user.Id.ToString()) // Kullanıcı Id'sini Claims'e ekliyoruz
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = viewModel.RememberMe
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Index", "Form");
                }

                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userExists = await _userService.GetUserByUsernameAsync(viewModel.Username);
                if (userExists != null)
                {
                    ModelState.AddModelError(string.Empty, "Bu kullanıcı adı zaten alınmış.");
                    return View(viewModel);
                }

                var newUser = new CreateUserDto
                {
                    Username = viewModel.Username,
                    Password = viewModel.Password
                };

                await _userService.AddUserAsync(newUser);

                return RedirectToAction("Login", "Account");
            }
            return View(viewModel);
        }
    }
}