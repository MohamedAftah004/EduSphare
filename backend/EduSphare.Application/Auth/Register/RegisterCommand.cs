using EduSphare.Application.Common;
using MediatR;

namespace EduSphare.Application.Auth.Register
{
    public sealed record RegisterCommand(string FirstName, string LastName, string Username, string Email, string Password)
        : IRequest<Result<Guid>>;
}
