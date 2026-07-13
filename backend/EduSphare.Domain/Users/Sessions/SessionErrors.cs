using EduSphare.Domain.Common;

namespace EduSphare.Domain.Users.Sessions;

public static class SessionErrors
{
    public static readonly Error NotFound =
        new(
            "Sessions.NotFound",
            "Session was not found.");

    public static readonly Error Expired =
        new(
            "Sessions.Expired",
            "Session has expired.");

    public static readonly Error Revoked =
        new(
            "Sessions.Revoked",
            "Session has been revoked.");

    public static readonly Error AlreadyRevoked =
        new(
            "Sessions.AlreadyRevoked",
            "Session is already revoked.");

    public static readonly Error InvalidRefreshToken =
        new(
            "Sessions.InvalidRefreshToken",
            "Refresh token is invalid.");

    public static readonly Error RefreshTokenExpired =
        new(
            "Sessions.RefreshTokenExpired",
            "Refresh token has expired.");
}