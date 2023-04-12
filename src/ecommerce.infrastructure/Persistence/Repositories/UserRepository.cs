using ecommerce.domain.Entities;
using ecommerce.domain.Repositories;

namespace ecommerce.infrastructure.Persistence.Repositories;
public class UserRepository : Repository<Users>, IUserRepository
{
    private readonly ApplicationDBContext context;
    public UserRepository(ApplicationDBContext context) : base(context)
        => this.context = context;
}
