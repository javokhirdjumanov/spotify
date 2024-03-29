﻿using Microsoft.AspNetCore.Mvc;
using spotify.bizlayer.Abstractions;
using spotify.core.Errors;
using spotify.core.Shared;
using spotify.datalayer.EfClasses;
using spotify.datalayer.Repositories;

namespace spotify.bizlayer.Services.OtpCodes;
public class VerifyOtpCodeCommandHandler : ICommandHandler<VerifyOtpCodeCommand, int>
{
    private readonly IUserRepository userRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IOtpCodeRepository otpCodeRepository;

    public VerifyOtpCodeCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IOtpCodeRepository otpCodeRepository)
    {
        this.userRepository = userRepository;
        this.unitOfWork = unitOfWork;
        this.otpCodeRepository = otpCodeRepository;
    }

    public async Task<Result<int>> Handle([FromBody] VerifyOtpCodeCommand request, CancellationToken cancellationToken)
    {
        var maybeUser = await userRepository.SelectUserWithOtpCodesAsync(request.userId);

        if (maybeUser is null)
            return Result.Failure<int>(DomainError.User.NotFound(request.userId));

        OtpCode? lastOtpCode = maybeUser.OtpCodes.OrderByDescending(p => p.CreatedAt).FirstOrDefault();

        if (lastOtpCode is null)
            return Result.Failure<int>(DomainError.OtpCode.InValid());

        if (lastOtpCode.IsExpired())
        {
            lastOtpCode.MarkAsExpired();
            otpCodeRepository.Update(lastOtpCode);
            await unitOfWork.SaveChangesAsync();

            return Result.Failure<int>(DomainError.OtpCode.Expired());
        }

        if (!lastOtpCode.IsValid(request.otpCode))
        {
            return Result.Failure<int>(
                DomainError.OtpCode.InValid());
        }

        lastOtpCode.MarkAsVerified();
        otpCodeRepository.Update(lastOtpCode);

        maybeUser.MarkAsActive();
        userRepository.Update(maybeUser);

        await unitOfWork.SaveChangesAsync();

        return maybeUser.Id;
    }
}
