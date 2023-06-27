using spotify.datalayer.EfClasses;
using WEBASE.EF;

namespace spotify.datalayer.Repositories;
public interface IUserRepository
    : IBaseEntityRepository<int, User, CreatedUserDlDto, UpdatedUserDlDto>
{
}
