using API.Data;
using API.Helpers;
using API.Interfeces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        
        public static IServiceCollection AddApplicationServices (this IServiceCollection services, IConfiguration config)
        {
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<LogUserActivity>();
            services.AddScoped<ILikedReposity, LikedReposity>();

            return services;


        }
    }
}