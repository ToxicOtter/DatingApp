using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions 
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            }); // Add DbContext as a service
            services.AddCors(); //add CORS
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRespository, IUserRespository>();

            return services;
        }
    }
}