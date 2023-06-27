using WEBASE.Attributes;
using WEBASE.Models;

namespace spotify.datalayer.Repositories;
public class UpdatedUserDlDto : UserDlDto<UpdatedUserDlDto>, IHaveIdProp<int>
{
    [LocalizedRequired]
    [LocalizedRange(1, int.MaxValue)]
    public int Id { get; set; }
}
