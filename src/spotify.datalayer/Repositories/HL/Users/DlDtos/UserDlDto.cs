using spotify.datalayer.EfClasses;
using WEBASE.EF;

namespace spotify.datalayer.Repositories;
public class UserDlDto<TDto> : EntityDto<TDto, User>
    where TDto : UserDlDto<TDto>
{

}
