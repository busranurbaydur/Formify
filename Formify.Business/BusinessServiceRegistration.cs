using Formify.Business.Abstract;
using Formify.Business.Concrete;
using Formify.Business.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Formify.Business
{
    public static class BusinessServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFieldService, FieldService>();

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}