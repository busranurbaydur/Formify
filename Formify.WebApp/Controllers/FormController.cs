using Formify.Business.Abstract;
using Formify.Business.Dtos.FormDtos;
using Formify.WebApp.ViewModels.FieldViewModels;
using Formify.WebApp.ViewModels.FormViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Formify.WebApp.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        public async Task<IActionResult> Index(string search)
        {
            var forms = await _formService.GetAllFormsAsync();

            if (!string.IsNullOrEmpty(search))
            {
                forms = forms.Where(f => f.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            var viewModel = new FormManagementViewModel
            {
                FormList = new FormListViewModel
                {
                    Forms = forms,
                    SearchQuery = search
                },
                FormCreate = new FormCreateViewModel()
            };

            return View(viewModel);
        }

        [HttpGet("Form/{formId}")]
        public async Task<IActionResult> Details(int formId)
        {
            var form = await _formService.GetFormByIdAsync(formId);
            if (form == null)
            {
                return NotFound();
            }

            var viewModel = new FormDetailsViewModel
            {
                Id = form.Id,
                Name = form.Name,
                Description = form.Description,
                Fields = form.Fields.Select(f => new FieldDetailsViewModel
                {
                    Name = f.Name,
                    Required = f.Required,
                    DataType = f.DataType
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FormManagementViewModel viewModel)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userIdClaim = User.FindFirst("UserId");
                if (userIdClaim != null)
                {
                    viewModel.FormCreate.CreatedBy = int.Parse(userIdClaim.Value);
                }
            }

            await _formService.AddFormAsync(viewModel.FormCreate.ToDto());
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _formService.DeleteFormAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}