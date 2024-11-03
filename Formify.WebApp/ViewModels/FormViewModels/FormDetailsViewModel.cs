using Formify.WebApp.ViewModels.FieldViewModels;

namespace Formify.WebApp.ViewModels.FormViewModels
{
    public class FormDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<FieldDetailsViewModel> Fields { get; set; } = new List<FieldDetailsViewModel>();
    }
}