namespace EduSphare.Application.Auth.Login
{
    public sealed record LoginResponse(
        string AccessToken,
        string RefreshToken,
        DateTime ExpiresAt);
}
