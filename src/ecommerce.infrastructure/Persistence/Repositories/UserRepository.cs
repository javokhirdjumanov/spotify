using ecommerce.domain.Entities;
using ecommerce.domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.infrastructure.Persistence.Repositories;
public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDBContext context)
        : base(context)
    { }

    public async ValueTask<IList<User>> GetAllUserWithAddress()
    {
        return context.Set<User>().Include(u => u.Address).ToList();
    }
}
