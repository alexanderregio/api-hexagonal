using Hexagonal.DbAdapter;
using Hexagonal.Domain.Adapters;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DbAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddDbAdapter(this IServiceCollection services, DbAdapterConfiguration configuration)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IDbAdapter, DbAdapter>();
            services.AddSingleton(configuration);
            services.AddAutoMapper(typeof(DbAdapterMapperProfile));

            return services;
        }
    }
}
