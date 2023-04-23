using ecommerce.domain.Entities;
using ecommerce.domain.Repositories;

namespace ecommerce.infrastructure.Persistence.Repositories;
public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(ApplicationDBContext context) 
        : base(context)
    { }
}
