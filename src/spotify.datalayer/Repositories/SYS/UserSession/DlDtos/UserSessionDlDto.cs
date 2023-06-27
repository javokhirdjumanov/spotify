using spotify.datalayer.EfClasses;
using WEBASE.EF;

namespace spotify.datalayer.Repositories;
public class UserSessionDlDto<TDto> : EntityDto<TDto, UserSession>
    where TDto : UserSessionDlDto<TDto>
{
}
