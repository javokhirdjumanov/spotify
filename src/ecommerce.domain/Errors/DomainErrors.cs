using ecommerce.domain.Shared;

namespace ecommerce.domain.Errors;
public static class DomainErrors
{
    public static class Users
    {
        public static readonly Func<Guid, Error> NotFound = id => new Error(
            code: "User.NotFound",
            message: $"The user with the identifier {id} was not found."); 
    }
    public static class Address
    {
        public static readonly Func<Guid, Error> NotFound = id => new Error(
            code: "Address.NotFound",
            message: $"The address with the identifier {id} was not found.");
    }
}
