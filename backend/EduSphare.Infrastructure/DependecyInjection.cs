using EduSphare.Application.Abstractions.Persistence;
using EduSphare.Domain.Users;
using EduSphare.Infrastructure.Persistence;
using EduSphare.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Application.Abstractions.Security;
using EduSphare.Infrastructure.Security;

namespace EduSphare.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IPasswordHasher, PasswordHasher>();

            services.AddScoped<IUnitOfWork>(sp =>
                sp.GetRequiredService<AppDbContext>());

            return services;
        }
    }
}
