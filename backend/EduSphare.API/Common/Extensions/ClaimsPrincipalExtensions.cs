using System.Security.Claims;

namespace EduSphare.API.Common;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal user)
    {
        var value = user.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(value))
            throw new UnauthorizedAccessException("User id claim was not found.");

        return Guid.Parse(value);
    }
}