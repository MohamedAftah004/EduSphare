namespace EduSphare.API.Auth.Contracts
{
    public sealed record LoginResponse(
        string AccessToken,
        string RefreshToken);
}
