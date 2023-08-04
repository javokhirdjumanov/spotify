using spotify.datalayer.EfClasses;
using spotify.datalayer.EfCode;

namespace spotify.datalayer.Repositories;
public class OtpCodeRepository : BaseRepository<OtpCode>, IOtpCodeRepository
{
    public OtpCodeRepository(EfCoreContext context) : base(context)
    { }
}
