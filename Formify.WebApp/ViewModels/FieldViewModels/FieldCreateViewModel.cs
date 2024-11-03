using Formify.Business.Dtos.FieldDtos;
using System.ComponentModel.DataAnnotations;

namespace Formify.WebApp.ViewModels.FieldViewModels
{
    public class FieldCreateViewModel
    {
        [Required(ErrorMessage = "Alan adı zorunludur.")]

        public string Name { get; set; }
        
        public bool Required { get; set; }

        public string DataType { get; set; }

        public CreateFieldDto ToDto()
        {
            return new CreateFieldDto
            {
                Name = this.Name,
                Required = this.Required,
                DataType = this.DataType
            };
        }
    }
}