// ECommerce.Application/Configuration/ServiceRegistrar.cs
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Application.Configuration
{
    public static class ServiceRegistrar
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}