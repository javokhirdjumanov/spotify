using AutoMapper;
using spotify.bizlayer.Services.Users;
using spotify.datalayer.EfClasses;

namespace spotify.bizlayer.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserResponse>()
                .ForMember(resp => resp.Status, cfg => cfg.MapFrom(user => user.Status.StatusName));
        }
    }
}
