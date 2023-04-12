namespace ecommerce.domain.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> SelectAllAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<T> SelectAsync(
            CancellationToken cancellationToken = default, 
            params object[] entityIds);

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
