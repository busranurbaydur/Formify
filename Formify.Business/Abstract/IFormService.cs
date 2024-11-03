using Formify.Business.Dtos.FormDtos;

namespace Formify.Business.Abstract
{
    public interface IFormService
    {
        Task<FormDto> GetFormByIdAsync(int id);

        Task<IEnumerable<FormDto>> GetAllFormsAsync();

        Task AddFormAsync(CreateFormDto createFormDto);

        Task UpdateFormAsync(FormDto formDto);

        Task DeleteFormAsync(int id);
    }
}