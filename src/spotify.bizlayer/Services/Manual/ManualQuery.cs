using spotify.bizlayer.Abstractions;

namespace spotify.bizlayer.Services.Manual
{
    public record StatusQuery(int id) : IQuery<GetAllStatusResponse>;
    public record StateQuery(int id) : IQuery<GetAllStateResponse>;
    public record RoleQuery(int id) : IQuery<GetAllRoleResponse>;
}
