using ecommerce.domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.infrastructure.Persistence.Repositories;
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDBContext context;
    public Repository(ApplicationDBContext context)
        => this.context = context;

    public void Insert(T entity)
        => this.context.Set<T>().Add(entity);

    public async Task<IReadOnlyList<T>> SelectAllAsync(
        CancellationToken cancellationToken = default)
    {
        return 
            await this.context
            .Set<T>()
            .ToListAsync(cancellationToken);
    }

    public async Task<T> SelectAsync(
        CancellationToken cancellationToken = default,
        params object[] entityIds)
    {
        return await this.context
            .Set<T>()
            .FindAsync(keyValues: entityIds, cancellationToken: cancellationToken);
    }
    
    public void Update(T entity)
        => this.context.Entry(entity).State = EntityState.Modified;

    public void Delete(T entity)
        => this.context.Set<T>().Remove(entity);
}
