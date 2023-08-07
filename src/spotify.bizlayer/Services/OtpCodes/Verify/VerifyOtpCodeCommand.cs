using spotify.bizlayer.Abstractions;

namespace spotify.bizlayer.Services.OtpCodes;
public record VerifyOtpCodeCommand(string OtpCode, int UserId) : ICommand<int>;
