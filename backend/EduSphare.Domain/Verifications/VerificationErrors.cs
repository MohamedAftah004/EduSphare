using EduSphare.Domain.Common;

namespace EduSphare.Domain.Verifications;

public static class VerificationErrors
{
    public static readonly Error InvalidCode =
        new(
            "Verification.InvalidCode",
            "Verification code is invalid.");

    public static readonly Error NotFound =
        new(
            "Verification.NotFound",
            "Verification code Not Found.");


    public static readonly Error ExpiredCode =
        new(
            "Verification.ExpiredCode",
            "Verification code has expired.");

    public static readonly Error AlreadyVerified =
        new(
            "Verification.AlreadyVerified",
            "Verification code has already been used.");
}