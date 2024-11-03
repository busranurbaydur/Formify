using Formify.Domain.Enums;

namespace Formify.WebApp.ViewModels.FieldViewModels
{
    public class FieldDetailsViewModel
    {
        public string Name { get; set; }
        public bool Required { get; set; }
        public DataType DataType { get; set; }
    }
}