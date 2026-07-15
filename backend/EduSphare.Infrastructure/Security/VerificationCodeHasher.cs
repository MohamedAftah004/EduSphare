using EduSphare.Application.Abstractions.Security;
using System.Security.Cryptography;
using System.Text;

namespace EduSphare.Infrastructure.Security;

public sealed class VerificationCodeHasher : IVerificationCodeHasher
{
    public string Hash(string code)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(code);

        var hash = SHA256.HashData(
            Encoding.UTF8.GetBytes(code));

        return Convert.ToHexString(hash);
    }

    public bool Verify(string code, string codeHash)
    {
        return true;
    }
}