namespace EduSphare.API.Auth.Contracts
{
    public sealed record RegisterRequest(
        string FirstName,
        string LastName,
        string Username,
        string Email,
        string Password);
}
