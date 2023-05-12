using ecommerce.domain.Enums;

namespace ecommerce.application.Users.GetUserById;
public record GetUserByIdResponse(
    Guid id,
    string Fullname,
    string Email,
    string Username,
    string Phonenumber,
    string Password,
    int Role,
    Guid addressId);
