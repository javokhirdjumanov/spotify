using Microsoft.EntityFrameworkCore;
using spotify.datalayer.EfClasses;
using WEBASE.EF;

namespace spotify.datalayer.EfCode;
public partial class EfCoreContext : DbContext
{
    public EfCoreContext(DbContextOptions<EfCoreContext> options)
        : base(options)
    { }

    #region ENUM
    public DbSet<OtpCodeStatus> OtpCodeStatuses { get; set; }
    public DbSet<SessionStatus> SessionStatuses { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    #endregion
    #region HL
    public DbSet<OtpCode> OtpCodes { get; set; }
    public DbSet<User> Users { get; set; }
    #endregion
    #region SYS
    public DbSet<UserSession> UserSessions { get; set; }
    #endregion
}
