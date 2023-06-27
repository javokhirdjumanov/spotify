using GenericServices;
using spotify.datalayer.EfClasses;
using WEBASE.EF;

namespace spotify.datalayer.Repositories;
public class UserSessionRepository
    : BaseEntityRepository<int, UserSession, CreatedUserSessionDlDto, UpdatedUserSessionDlDto>,
    IUserSessionRepository
{
    public UserSessionRepository(ICrudServices crudServices)
        : base(crudServices)
    { }

}
