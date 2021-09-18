using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TestReal.Persistence;
using TestReal.Persistence.Context;
using TestReal.Services.Interfaces;
using TestReal.Services.Services;

namespace TestReal.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTestRealPersistense(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
            services.AddScoped<IUserRegistrationService, UserRegistrationService>();
            services.AddScoped<ICalculationService, CalculationService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}