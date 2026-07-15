using EduSphare.Application.Abstractions.Communication;
using EduSphare.Application.Abstractions.Persistence;
using EduSphare.Application.Abstractions.Security;
using EduSphare.Application.Auth;
using EduSphare.Domain.Users;
using EduSphare.Infrastructure.Communication;
using EduSphare.Infrastructure.Options;
using EduSphare.Infrastructure.Persistence;
using EduSphare.Infrastructure.Persistence.Repositories;
using EduSphare.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduSphare.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));
        });

        services.Configure<EmailOptions>(
            configuration.GetSection(EmailOptions.SectionName));

        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IVerificationRepository, VerificationRepository>();

        // Security
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<IVerificationCodeGenerator, VerificationCodeGenerator>();
        services.AddSingleton<IVerificationCodeHasher, VerificationCodeHasher>();

        // Communication
        services.AddScoped<IEmailSender, EmailSender>();

        services.Configure<EmailOptions>(
            configuration.GetSection(EmailOptions.SectionName));


        // Unit Of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();


        return services;
    }
}