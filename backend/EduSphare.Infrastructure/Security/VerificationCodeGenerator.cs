using EduSphare.Application.Abstractions.Security;

namespace EduSphare.Infrastructure.Security;

public sealed class VerificationCodeGenerator : IVerificationCodeGenerator
{
    public string Generate()
    {
        return Random.Shared
            .Next(100000, 1000000)
            .ToString();
    }
}