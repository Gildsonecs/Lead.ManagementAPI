using Lead.Management.Application;
using Lead.Management.Application.Interfaces;
using Lead.Management.Domain.Repositories;
using Lead.Management.Infrastruture.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lead.Management.CrossCutting.IoC
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterApplication(services);
        }

        public static void RegisterApplication(IServiceCollection services)
        {
            services.AddScoped<IInvitedApplication, InvitedApplication>();
            services.AddSingleton<IEmailSender, EmailSender>();
        }

        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IInvitedRepository, InvitedRepository>();          
        }
    }
}
