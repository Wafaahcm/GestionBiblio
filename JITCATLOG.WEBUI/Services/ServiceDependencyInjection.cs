using JITCATALOG.API.Controllers;
using JITCATALOG.APPLICATION.Contracts.Book.Commands.Create;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JITCATLOG.WEBUI.Services
{

    public static class MediatRConfig
    {
        public static void AddMediatRConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddMediatR(_ => _.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
       
        }
    }
}
