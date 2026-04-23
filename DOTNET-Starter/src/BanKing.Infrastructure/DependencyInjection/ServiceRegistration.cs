using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BanKing.Domain.Interfaces;
using BanKing.Infrastructure.Data;
using BanKing.Infrastructure.Repositories;

namespace BanKing.Infrastructure.DependencyInjection;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>
            // SQL SERVER SETUP
            // options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            

            // MySql SETUP
            {
                options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString)
                );
            }
        );


        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}