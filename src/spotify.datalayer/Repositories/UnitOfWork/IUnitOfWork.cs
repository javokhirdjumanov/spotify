using Microsoft.EntityFrameworkCore.Storage;
using spotify.datalayer.EfCode;

namespace spotify.datalayer.Repositories;
public interface IUnitOfWork
{
    EfCoreContext Context { get; }
    IDbContextTransaction CurrentTransaction { get; }

    Task<TRepository> GetRepository<TRepository>();
    Task<IDbContextTransaction> BeginTransaction();
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    Task CommitAsync();
    Task RollbackAsync();
}
