using spotify.datalayer.EfClasses;
using WEBASE.EF;

namespace spotify.datalayer.Repositories;
public interface IOtpCodeRepository
    : IBaseEntityRepository<int, OtpCode>
{
}
