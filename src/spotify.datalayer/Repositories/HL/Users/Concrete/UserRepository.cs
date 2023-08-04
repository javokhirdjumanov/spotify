using GenericServices;
using Microsoft.EntityFrameworkCore;
using spotify.datalayer.EfClasses;
using spotify.datalayer.EfCode;
using WEBASE.EF;

namespace spotify.datalayer.Repositories;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(EfCoreContext context) : base(context)
    { }

    public async Task<User> SelectUserWithEmailAsync(string email)
    {
        return await this.context
            .Set<User>()
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();
    }

    public async Task<User> SelectUserWithOtpCodesAsync(int userId)
    {
        return await this.context
            .Set<User>()
            .Include(u => u.OtpCodes)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }
}
