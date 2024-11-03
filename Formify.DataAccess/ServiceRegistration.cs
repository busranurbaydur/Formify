using Formify.DataAccess.Context;
using Formify.DataAccess.Repositories.Abstract;
using Formify.DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Formify.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFieldRepository, FieldRepository>();
        }
    }
}