using spotify.bizlayer.Abstractions;

namespace spotify.bizlayer.Services.OtpCodes;
public record SendOtpCommand(int userId, string email) : ICommand<bool>;
