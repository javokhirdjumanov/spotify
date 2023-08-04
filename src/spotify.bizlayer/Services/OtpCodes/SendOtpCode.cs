using Microsoft.AspNetCore.Http.HttpResults;
using spotify.datalayer.Repositories;

namespace spotify.bizlayer.Services;
public class SendOtpCode
{
    private IUserRepository _userRepository;
    private IEmailService _emailService;
    private IUnitOfWork _unitOfWork;

    public SendOtpCode(
        IUserRepository userRepository,
        IEmailService emailService,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _emailService = emailService;
        _unitOfWork = unitOfWork;
    }


    public async Task<bool> Handle(int userId, string email)
    {
        
    }

}
