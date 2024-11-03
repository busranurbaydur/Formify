using Formify.Domain.Entities;

namespace Formify.DataAccess.Repositories.Abstract
{
    public interface IFormRepository : IGenericRepository<Form>
    {
        Task<Form> GetFormWithFieldsAsync(int id);
    }
}