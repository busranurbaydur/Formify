using Formify.DataAccess.Context;
using Formify.DataAccess.Repositories.Abstract;
using Formify.Domain.Entities;

namespace Formify.DataAccess.Repositories.Concrete
{
    public class FieldRepository : GenericRepository<Field>, IFieldRepository
    {
        public FieldRepository(AppDbContext context) : base(context)
        {
        }
    }
}