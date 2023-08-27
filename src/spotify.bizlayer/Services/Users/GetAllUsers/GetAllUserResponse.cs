namespace spotify.bizlayer.Services.Users;
public record GetAllUserResponse(IList<UserResponse> allUsers);

public record UserResponse(
    string FirstName,
    string LastName,
    string Phone,
    string Email,
    string Role,
    string Status);