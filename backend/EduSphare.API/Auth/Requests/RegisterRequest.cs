namespace EduSphare.API.Auth.Requests
{
    public sealed record RegisterRequest(
        string FirstName,
        string LastName,
        string Username,
        string Email,
        string Password);
}
