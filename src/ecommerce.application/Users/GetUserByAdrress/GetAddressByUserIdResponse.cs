namespace ecommerce.application.Users.GetUserByAdrress
{
    public record GetAddressByUserIdResponse(
        Guid userId,
        Guid addressId,
        string Country,
        string City,
        string Region,
        string Street,
        short PostalCode);
}
