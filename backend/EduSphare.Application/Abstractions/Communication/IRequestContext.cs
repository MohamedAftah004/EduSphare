using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Application.Abstractions.Communication
{
    public interface IRequestContext
    {
        string? IpAddress { get; }

        string? UserAgent { get; }
    }
}
