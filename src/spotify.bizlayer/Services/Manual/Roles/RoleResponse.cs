namespace spotify.bizlayer.Services.Manual;
public record GetAllRoleResponse(IList<RoleResponse> allRoles);
public record RoleResponse(int Id, string Name);
