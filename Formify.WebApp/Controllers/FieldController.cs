using Formify.Business.Abstract;
using Formify.WebApp.ViewModels.FieldViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Formify.WebApp.Controllers
{
    public class FieldController : Controller
    {
        private readonly IFieldService _fieldService;

        public FieldController(IFieldService fieldService)
        {
            _fieldService = fieldService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var field = await _fieldService.GetFieldByIdAsync(id);
            if (field == null)
            {
                return NotFound();
            }

            var viewModel = new FieldDetailsViewModel
            {
                Name = field.Name,
                Required = field.Required,
                DataType = field.DataType
            };
            return View(viewModel);
        }
    }
}