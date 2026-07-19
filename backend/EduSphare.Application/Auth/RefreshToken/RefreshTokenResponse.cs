namespace EduSphare.Application.Auth.RefreshToken;

public sealed record RefreshTokenResponse(
    string AccessToken,
    string RefreshToken);