namespace spotify.bizlayer.Services.Users;
public record GetAllUserResponse(IList<AllUserResponse> allUsers);

public record AllUserResponse(
    string FirstName,
    string LastName,
    string Phone,
    string Email,
    string Role,
    string Status);