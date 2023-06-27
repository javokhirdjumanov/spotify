using spotify.datalayer.EfClasses;
using WEBASE.Attributes;
using WEBASE.Models;

namespace spotify.datalayer.Repositories;
public class UpdatedUserSessionDlDto : UserSessionDlDto<UpdatedUserSessionDlDto>, IHaveIdProp<int>
{
    [LocalizedRequired, LocalizedRange(1, int.MaxValue)]
    public int Id { get; set; }
}
