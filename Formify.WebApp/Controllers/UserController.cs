using Formify.Business.Abstract;
using Formify.WebApp.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Formify.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            var viewModel = new UserListViewModel { Users = users };
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new UserDetailsViewModel
            {
                Id = user.Id,
                Username = user.Username
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddUserAsync(viewModel.ToDto());
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
    }
}