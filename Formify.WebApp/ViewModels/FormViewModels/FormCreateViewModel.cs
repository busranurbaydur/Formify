using Formify.Business.Dtos.FieldDtos;
using System.ComponentModel.DataAnnotations;

namespace Formify.Business.Dtos.FormDtos
{
    public class FormCreateViewModel
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CreatedBy { get; set; }

        [MinLength(1, ErrorMessage = "En az bir alan eklenmelidir.")]
        public List<FieldDto> Fields { get; set; } = new List<FieldDto>();

        public CreateFormDto ToDto()
        {
            return new CreateFormDto
            {
                Name = this.Name,
                Description = this.Description,
                CreatedAt = this.CreatedAt,
                CreatedBy = this.CreatedBy,
                Fields = this.Fields
            };
        }
    }
}