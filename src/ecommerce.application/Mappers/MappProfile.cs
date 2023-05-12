using AutoMapper;
using ecommerce.application.Users.GetUserById;
using ecommerce.domain.Entities;

namespace ecommerce.application.Mappers;
public class MappProfile : Profile
{
    public MappProfile()
    {
        CreateMap<User, GetUserByIdResponse>();
    }
}
