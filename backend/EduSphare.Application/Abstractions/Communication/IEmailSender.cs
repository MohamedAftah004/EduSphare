using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Application.Abstractions.Communication
{
    public interface IEmailSender
    {
        Task SendAsync(
            string to,
            string subject,
            string body,
            CancellationToken cancellationToken = default
        );
    }
}
