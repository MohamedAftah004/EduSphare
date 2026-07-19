using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;

namespace EduSphare.Application
{
    public static class DependecyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                {

                    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
            
        }

    }
}
