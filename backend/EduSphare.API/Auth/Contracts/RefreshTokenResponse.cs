namespace EduSphare.API.Auth.Contracts;

public sealed record RefreshTokenResponse(
    string AccessToken,
    string RefreshToken);