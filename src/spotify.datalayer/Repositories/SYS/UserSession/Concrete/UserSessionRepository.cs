using GenericServices;
using spotify.datalayer.EfClasses;
using spotify.datalayer.EfCode;
using WEBASE.EF;

namespace spotify.datalayer.Repositories;
public class UserSessionRepository : BaseRepository<UserSession>, IUserSessionRepository
{
    public UserSessionRepository(EfCoreContext context)
        : base(context)
    { }
}
