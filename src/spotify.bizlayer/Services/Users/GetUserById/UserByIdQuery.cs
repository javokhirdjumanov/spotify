using spotify.bizlayer.Abstractions;

namespace spotify.bizlayer.Services.Users;
public record UserByIdQuery(int userId) : IQuery<UserByIdResponse>;
