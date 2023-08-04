using Microsoft.EntityFrameworkCore;
using spotify.datalayer.EfCode;

namespace spotify.datalayer.Repositories;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly EfCoreContext context;

    public BaseRepository(EfCoreContext context) => this.context = context;

    public void Insert(T entity) =>
        this.context
        .Set<T>()
        .Add(entity);

    public async Task<T> SelectAsync(
        CancellationToken cancellationToken = default,
        params object[] entityIds)
    {
        return await this.context
            .Set<T>()
            .FindAsync(
                keyValues: entityIds,
                cancellationToken: cancellationToken);
    }

    public IQueryable<T> SelectAllAsync()
    {
        return context.Set<T>();
    }

    public void Update(T entity) =>
        this.context.Entry(entity).State = EntityState.Modified;

    public void Delete(T entity) =>
        this.context
        .Set<T>()
        .Remove(entity);

    public void ExacuteSqlQuery(string sqlQury)
    {
        context.Database.ExecuteSqlRaw(sqlQury);
    }
}