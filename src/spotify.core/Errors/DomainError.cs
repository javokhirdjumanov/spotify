using spotify.core.Shared;

namespace spotify.core.Errors;
public static class DomainError
{
    public static class User
    {
        public static readonly Func<Guid, Error> NotFound = id => new Error(
            code: "User NotFound",
            message: $"The user with the identifier {id} was not found.");

        public static readonly Func<string, string, Error> UserNotFoundByCredentials = (email, password) => new Error(
            code: "Email or Password is not valid",
            message: $"The user with the identifier {email},{password} was not found.");
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
}
