using AutoMapper;
using spotify.bizlayer.Services.Users;
using spotify.datalayer.EfClasses;

namespace spotify.bizlayer.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, AllUserResponse>()
                .ForMember(a => a.Status, cfg => cfg.MapFrom(user => user.Status.StatusName));
        }
    }
}
