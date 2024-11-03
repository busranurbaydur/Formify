using Formify.DataAccess.Context;
using Formify.DataAccess.Repositories.Abstract;

namespace Formify.DataAccess.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IFormRepository Forms { get; }
        public IUserRepository Users { get; }
        public IFieldRepository Fields { get; } // Field repository eklendi

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Forms = new FormRepository(context);
            Users = new UserRepository(context);
            Fields = new FieldRepository(context); // Field repository başlatıldı
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}