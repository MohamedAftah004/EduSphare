namespace EduSphare.API.Auth.Contracts;

public sealed record ResetPasswordRequest(
    string Email,
    string Code,
    string NewPassword);
