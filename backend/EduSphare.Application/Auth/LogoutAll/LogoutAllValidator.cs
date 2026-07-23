using FluentValidation;

namespace EduSphare.Application.Auth.LogoutAll;

public sealed class LogoutAllValidator : AbstractValidator<LogoutAllCommand>
{
    public LogoutAllValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User ID is required.");
    }
}
