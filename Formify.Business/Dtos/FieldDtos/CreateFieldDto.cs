namespace Formify.Business.Dtos.FieldDtos
{
    public class CreateFieldDto
    {
        public bool Required { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
    }
}