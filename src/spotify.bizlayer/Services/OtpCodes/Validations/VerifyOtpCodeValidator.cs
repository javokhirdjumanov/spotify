﻿using FluentValidation;

namespace spotify.bizlayer.Services.OtpCodes;
public class VerifyOtpCodeValidator : AbstractValidator<VerifyOtpCodeCommand>
{
    public VerifyOtpCodeValidator()
    {
        RuleFor(otp => otp.otpCode)
            .NotNull().Empty().WithMessage("OtpCode is required")
            .Length(6).WithMessage("OtpCode length must equel to 6");

        RuleFor(otp => otp.userId)
                .NotNull().NotEmpty().WithMessage("UserId is required")
                .NotEqual(default(int)).WithMessage("It does not equels default value");
    }
}
