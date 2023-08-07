using spotify.bizlayer.Services.OtpCodes;
using spotify.core.Errors;
using spotify.core.Shared;
using spotify.datalayer.EfClasses;
using spotify.datalayer.Repositories;

namespace spotify.bizlayer.Services;
public class SendOtpCommandHandler
{
    private IUserRepository _userRepository;
    private IEmailService _emailService;
    private IUnitOfWork _unitOfWork;

    public SendOtpCommandHandler(IUserRepository userRepository, IEmailService emailService, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _emailService = emailService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<bool>> Handle(SendOtpCommand request, CancellationToken cancellationToken)
    {
        var maybeUser = await this._userRepository.SelectUserWithOtpCodesAsync(request.userId);

        if(maybeUser is null)
            return Result.Failure<bool>(DomainError.User.NotFound(request.userId));

        if(maybeUser.Email != request.email)
            return Result.Failure<bool>(DomainError.User.NotFound(request.userId));

        var lastOtp = maybeUser.OtpCodes.OrderByDescending(o => o.CreatedAt).FirstOrDefault();

        if (lastOtp is not null && !lastOtp.IsExpired())
            return Result.Success<bool>(true);

        var newOtpCode = new OtpCode(OtpCodeHelper.GenerateOtpCode());

        maybeUser.OtpCodes.Add(newOtpCode);

        var mailRequest = new MailRequest(
            toEmail: request.email,
            subject: EmailMessageExample.GetEmailSubject(),
            body: EmailMessageExample.GetEmailBody(maybeUser.FirstName, newOtpCode.Code));

        await this._emailService.SendEmailAsync(mailRequest, cancellationToken);
        await this._unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success<bool>(true);
    }
}