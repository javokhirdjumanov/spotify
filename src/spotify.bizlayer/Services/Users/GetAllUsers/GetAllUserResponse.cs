namespace spotify.bizlayer.Services.Users;
public record GetAllUserResponse(IList<AllUserResponse> allUsers);

public record AllUserResponse(
    string firstName,
    string lastName,
    string phone,
    string email,
    string role,
    string status);