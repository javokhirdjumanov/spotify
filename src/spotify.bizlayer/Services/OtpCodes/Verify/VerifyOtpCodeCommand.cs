using spotify.bizlayer.Abstractions;

namespace spotify.bizlayer.Services.OtpCodes;
public record VerifyOtpCodeCommand(string otpCode, int userId) : ICommand<int>;
