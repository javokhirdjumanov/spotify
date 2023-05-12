using ecommerce.application.Users.GetUserById;

namespace ecommerce.application.Users.GetAllUsers;
public record GetAllUserResponse(
    IList<GetUserByIdResponse> AllUsers);
