using spotify.bizlayer.Services.Manual;

namespace spotify.bizlayer.Services.Users;
public record UserByIdResponse(
    int Id,
    string? FirstName,
    string? LastName,
    string? Phone,
    string? Email,
    RoleResponse Role,
    DateTime? RegisterAt,
    StatusResponse Status,
    StateResponse State);
