using GenericServices;
using spotify.datalayer.EfClasses;
using WEBASE.EF;

namespace spotify.datalayer.Repositories;
public class UserRepository
    : BaseEntityRepository<int, User, CreatedUserDlDto, UpdatedUserDlDto>,
    IUserRepository
{
    public UserRepository(ICrudServices crudServices)
        : base(crudServices)
    { }


}
