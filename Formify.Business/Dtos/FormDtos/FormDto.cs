using Formify.Business.Dtos.FieldDtos;

namespace Formify.Business.Dtos.FormDtos
{
    public class FormDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public List<FieldDto> Fields { get; set; } = new List<FieldDto>();
    }
}