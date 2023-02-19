using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<InvoiceContext>());

            services.AddDbContext<InvoiceContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                   builder => builder.MigrationsAssembly(typeof(InvoiceContext).Assembly.FullName)));
            
            return services;
        }
    }
}
