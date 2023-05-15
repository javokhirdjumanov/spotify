using ecommerce.domain.Entities;
using ecommerce.domain.Repositories;

namespace ecommerce.infrastructure.Persistence.Repositories;
public sealed class OtpCodeRepository 
    : Repository<OtpCode>, IOtpCodeRepository
{
    public OtpCodeRepository(ApplicationDBContext context) 
        : base(context)
    { }
}
