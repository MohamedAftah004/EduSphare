namespace EduSphare.API.Auth.Contracts;

public sealed record VerifyEmailRequest(
    string Email,
    string Code);