using ecommerce.domain.Repositories;

namespace ecommerce.infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext context;
        public UnitOfWork(ApplicationDBContext context)
            => this.context = context;

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
            => await this.context.SaveChangesAsync(cancellationToken);
    }
}
