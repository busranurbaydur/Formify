using Formify.Business.Dtos.FieldDtos;

namespace Formify.Business.Abstract
{
    public interface IFieldService
    {
        Task<FieldDto> GetFieldByIdAsync(int id);

        Task<IEnumerable<FieldDto>> GetFieldsByFormIdAsync(int formId);

        Task AddFieldAsync(CreateFieldDto fieldDto);

        Task UpdateFieldAsync(FieldDto fieldDto);

        Task DeleteFieldAsync(int id);
    }
}