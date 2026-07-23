using EduSphare.Application.Abstractions.Communication;
using EduSphare.Application.Abstractions.Persistence;
using EduSphare.Application.Abstractions.Security;
using EduSphare.Application.Auth;
using EduSphare.Domain.Users;
using EduSphare.Domain.Users.Sessions;
using EduSphare.Infrastructure.Communication;
using EduSphare.Infrastructure.Options;
using EduSphare.Infrastructure.Persistence;
using EduSphare.Infrastructure.Persistence.Repositories;
using EduSphare.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EduSphare.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Database
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));
        });

        // Email Options
        services.Configure<EmailOptions>(
            configuration.GetSection(EmailOptions.SectionName));

        // JWT Options
        services.Configure<JwtOptions>(
            configuration.GetSection(JwtOptions.SectionName));

        var jwtOptions = configuration
            .GetSection(JwtOptions.SectionName)
            .Get<JwtOptions>()!;

        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IVerificationRepository, VerificationRepository>();
        services.AddScoped<Application.Auth.IUserSessionRepository, UserSessionRepository>();

        // Security
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IRefreshTokenGenerator, RefreshTokenGenerator>();
        services.AddScoped<IRefreshTokenHasher, RefreshTokenHasher>();

        services.AddSingleton<IVerificationCodeGenerator, VerificationCodeGenerator>();
        services.AddSingleton<IVerificationCodeHasher, VerificationCodeHasher>();

        // Communication
        services.AddScoped<IEmailSender, EmailSender>();

        services.AddHttpContextAccessor();
        services.AddScoped<IRequestContext, RequestContext>();

        // Authentication
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.Issuer,

                    ValidateAudience = true,
                    ValidAudience = jwtOptions.Audience,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),

                    ClockSkew = TimeSpan.Zero
                };

                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        var sessionIdClaim = context.Principal?.FindFirst("session_id")?.Value
                            ?? context.Principal?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value;

                        if (string.IsNullOrEmpty(sessionIdClaim) || !Guid.TryParse(sessionIdClaim, out var sessionId))
                        {
                            context.Fail("Invalid session claim in token.");
                            return;
                        }

                        var userSessionRepository = context.HttpContext.RequestServices
                            .GetRequiredService<IUserSessionRepository>();

                        var session = await userSessionRepository.GetByIdAsync(
                            sessionId,
                            context.HttpContext.RequestAborted);

                        if (session is null || !session.IsActive)
                        {
                            context.Fail("Session is inactive or has been revoked.");
                            return;
                        }
                    }
                };
            });

        // Unit Of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}