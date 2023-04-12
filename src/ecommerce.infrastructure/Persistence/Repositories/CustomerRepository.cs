using ecommerce.domain.Entities;
using ecommerce.domain.Repositories;

namespace ecommerce.infrastructure.Persistence.Repositories;
public class CustomerRepository : Repository<Customers>, ICustomerRepository
{
    private readonly ApplicationDBContext context;
    public CustomerRepository(ApplicationDBContext context) : base(context)
        => this.context = context;
}
