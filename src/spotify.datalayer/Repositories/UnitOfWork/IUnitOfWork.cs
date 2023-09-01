using Microsoft.EntityFrameworkCore.Storage;
using spotify.datalayer.EfCode;

namespace spotify.datalayer.Repositories;
public interface IUnitOfWork
{
    IDbContextTransaction CurrentTransaction { get; }
    EfCoreContext GetContext();
    Task<TRepository> GetRepository<TRepository>();
    Task<IDbContextTransaction> BeginTransaction();
    Task SaveChangesAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
