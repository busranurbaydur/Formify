namespace Formify.Business.Dtos.FormDtos
{
    public class FormListViewModel
    {
        public IEnumerable<FormDto> Forms { get; set; }
        public string SearchQuery { get; set; }
    }
}