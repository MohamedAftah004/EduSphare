using EduSphare.Application.Abstractions.Security;
using EduSphare.Domain.Users.ValueObjects;
using Microsoft.AspNetCore.Identity;

public sealed class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<object> _hasher = new();

    public PasswordHash Hash(string password)
    {
        var hash = _hasher.HashPassword(null!, password);

        return PasswordHash.Create(hash);
    }

    public bool Verify(string password, PasswordHash passwordHash)
    {
        var result = _hasher.VerifyHashedPassword(
            null!,
            passwordHash.Value,
            password);

        return result != PasswordVerificationResult.Failed;
    }
}