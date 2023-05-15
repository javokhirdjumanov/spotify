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
    public static class OtpCode
    {
        public static readonly Func<Error> InValid = () => new Error(
            code: "Otp InValid",
            message: "Invalid otp code");

        public static readonly Func<Error> Expired = () => new Error(
            code: "Otp.Expired",
            message: "Expired otp code");
    }
    public static class Address
    {
        public static readonly Func<Guid, Error> NotFound = id => new Error(
            code: "Address.NotFound",
            message: $"The address with the identifier {id} was not found.");
    }
}
