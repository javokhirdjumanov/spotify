using GenericServices;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using spotify.datalayer.EfCode;

namespace spotify.datalayer.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly IServiceProvider _serviceProvider;
    public UnitOfWork(ICrudServices crudServices, IServiceProvider serviceProvider)
    {
        Context = (EfCoreContext)crudServices.Context;
        CrudServicesAsync = crudServices;
        _serviceProvider = serviceProvider;
    }
    public ICrudServices CrudServicesAsync { get; }
    public EfCoreContext Context { get; }
    public IDbContextTransaction CurrentTransaction { get => Context.Database.CurrentTransaction; }

    public Task<IDbContextTransaction> BeginTransaction()
    {
        return Context.Database.BeginTransactionAsync();
    }
    public async Task<TRepository> GetRepository<TRepository>()
    {
        return _serviceProvider.GetRequiredService<TRepository>();
    }
    public Task SaveChangesAsync()
    {
        return Context.SaveChangesAsync();
    }
    public async Task CommitAsync()
    {
        SaveChangesAsync();
        if (Context.Database.CurrentTransaction != null)
        {
            Context.Database.CurrentTransaction.Commit();
        }
    }
    public async Task RollbackAsync()
    {
        if (Context.Database.CurrentTransaction != null)
        {
            Context.Database.CurrentTransaction.Rollback();
        }
    }
}
