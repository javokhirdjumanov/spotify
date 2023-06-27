using spotify.datalayer.EfClasses;
using WEBASE.EF;

namespace spotify.datalayer.Repositories;
public interface IUserSessionRepository
    : IBaseEntityRepository<int, UserSession, CreatedUserSessionDlDto, UpdatedUserSessionDlDto>
{
}
