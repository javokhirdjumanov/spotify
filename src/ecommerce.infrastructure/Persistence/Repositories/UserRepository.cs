using ecommerce.domain.Entities;
using ecommerce.domain.Repositories;

namespace ecommerce.infrastructure.Persistence.Repositories;
public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDBContext context) 
        : base(context)
    { }
}
