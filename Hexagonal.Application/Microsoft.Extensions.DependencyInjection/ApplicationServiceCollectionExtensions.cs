using Hexagonal.Application;
using Hexagonal.Domain.Services;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
