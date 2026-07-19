using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Application.Abstractions.Communication;
using Microsoft.AspNetCore.Http;

namespace EduSphare.Infrastructure.Communication
{
    public sealed class RequestContext : IRequestContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? IpAddress => _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();

        public string? UserAgent => _httpContextAccessor.HttpContext?.Request.Headers["User-Agent"].ToString();
    }
}
