using GenericServices;
using spotify.datalayer.EfClasses;
using WEBASE.EF;

namespace spotify.datalayer.Repositories;
public class OtpCodeRepository
    : BaseEntityRepository<int, OtpCode>,
    IOtpCodeRepository
{
    public OtpCodeRepository(ICrudServices crudServices)
        : base(crudServices)
    { }


}
