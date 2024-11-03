using System.ComponentModel.DataAnnotations;
using DataType = Formify.Domain.Enums.DataType;

namespace Formify.Business.Dtos.FieldDtos
{
    public class FieldDto
    {
        public bool Required { get; set; }
        [Required(ErrorMessage = "Alan adı zorunludur.")]
        public string Name { get; set; }
        public DataType DataType { get; set; }
    }
}