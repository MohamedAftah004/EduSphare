namespace EduSphare.Infrastructure.Options;

public sealed class EmailOptions
{
    public const string SectionName = "EmailSettings";

    public string SmtpHost { get; init; } = string.Empty;
    public int SmtpPort { get; init; }

    public string FromEmail { get; init; } = string.Empty;
    public string FromName { get; init; } = string.Empty;

    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;

    public bool EnableSsl { get; init; }

    public int TimeoutSeconds { get; init; }
}