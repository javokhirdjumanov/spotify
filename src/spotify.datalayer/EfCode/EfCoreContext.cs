using Microsoft.EntityFrameworkCore;
using WEBASE.EF;

namespace spotify.datalayer.EfCode
{
    public partial class EfCoreContext : BaseDbContext
    {
        public EfCoreContext(DbContextOptions options)
            : base(options)
        { }

    }
}
