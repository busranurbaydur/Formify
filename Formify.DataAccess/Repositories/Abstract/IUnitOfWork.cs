namespace Formify.DataAccess.Repositories.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IFormRepository Forms { get; }
        IUserRepository Users { get; }
        IFieldRepository Fields { get; }

        Task<int> CompleteAsync();
    }
}