using spotify.datalayer.EfClasses;
using WEBASE.EF;

namespace spotify.datalayer.Repositories;
public interface IUserRepository : IBaseRepository<User>
{
    Task<User> SelectUserWithEmailAsync(string email);
    Task<User> SelectUserWithOtpCodesAsync(int userId);
}
