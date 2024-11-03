using Formify.DataAccess.Context;
using Formify.DataAccess.Repositories.Abstract;
using Formify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Formify.DataAccess.Repositories.Concrete
{
    public class FormRepository : GenericRepository<Form>, IFormRepository
    {
        public FormRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Form> GetFormWithFieldsAsync(int id)
        {
            return await _context.Forms
                .Include(f => f.Fields)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}