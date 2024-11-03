using Formify.Business.Dtos.FormDtos;

namespace Formify.WebApp.ViewModels.FormViewModels
{
    public class FormManagementViewModel
    {
        public FormListViewModel FormList { get; set; }
        public FormCreateViewModel FormCreate { get; set; }
    }
}