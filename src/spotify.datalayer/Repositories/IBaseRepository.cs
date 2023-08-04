namespace spotify.datalayer.Repositories;
public interface IBaseRepository<T> where T : class
{
    Task<T> SelectAsync(CancellationToken cancellationToken = default, params object[] entityIds);
    public IQueryable<T> SelectAllAsync();
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
    void ExacuteSqlQuery(string sqlQury);
}
