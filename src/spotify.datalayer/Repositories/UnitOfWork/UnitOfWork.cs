using GenericServices;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using spotify.datalayer.EfCode;

namespace spotify.datalayer.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly IServiceProvider _serviceProvider;
    private readonly EfCoreContext context;
    public UnitOfWork(IServiceProvider serviceProvider, EfCoreContext context)
    {
        _serviceProvider = serviceProvider;
        this.context = context;
    }

    public IDbContextTransaction CurrentTransaction { get => context.Database.CurrentTransaction; }
    public EfCoreContext GetContext() => this.context;
    public Task<IDbContextTransaction> BeginTransaction()
    {
        return context.Database.BeginTransactionAsync();
    }
    public async Task<TRepository> GetRepository<TRepository>()
    {
        return _serviceProvider.GetRequiredService<TRepository>();
    }
    public Task SaveChangesAsync()
    {
        return context.SaveChangesAsync();
    }
    public async Task CommitAsync()
    {
        SaveChangesAsync();
        if (context.Database.CurrentTransaction != null)
        {
            context.Database.CurrentTransaction.Commit();
        }
    }
    public async Task RollbackAsync()
    {
        if (context.Database.CurrentTransaction != null)
        {
            context.Database.CurrentTransaction.Rollback();
        }
    }
}
