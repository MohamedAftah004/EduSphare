using EduSphare.Application.Abstractions.Communication;
using EduSphare.Infrastructure.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EduSphare.Infrastructure.Communication;

public sealed class EmailSender : IEmailSender
{
    private readonly EmailOptions _options;

    public EmailSender(IOptions<EmailOptions> options)
    {
        _options = options.Value;
    }

    public async Task SendAsync(
        string to,
        string subject,
        string body,
        CancellationToken cancellationToken = default)
    {
        var message = new MimeMessage();

        message.From.Add(
            new MailboxAddress(
                _options.FromName,
                _options.FromEmail));

        message.To.Add(
            MailboxAddress.Parse(to));

        message.Subject = subject;

        message.Body = new TextPart("plain")
        {
            Text = body
        };

        using var smtp = new SmtpClient();

        smtp.Timeout = _options.TimeoutSeconds * 1000;

        await smtp.ConnectAsync(
            _options.SmtpHost,
            _options.SmtpPort,
            _options.EnableSsl
                ? SecureSocketOptions.StartTls
                : SecureSocketOptions.None,
            cancellationToken);

        await smtp.AuthenticateAsync(
            _options.Username,
            _options.Password,
            cancellationToken);

        await smtp.SendAsync(
            message,
            cancellationToken);

        await smtp.DisconnectAsync(
            true,
            cancellationToken);
    }
}