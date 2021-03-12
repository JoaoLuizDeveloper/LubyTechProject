using LubyTechAPI.Repository;
using LubyTechAPI.Repository.IRepository;
using Microsoft.Extensions.DependencyInjection;

namespace LubyTechAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            return services;        
        }
    }
}
