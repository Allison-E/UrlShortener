using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Persistence.Contexts;

namespace UrlShortener.Persistence.Extensions;
public static class ServicesExtension
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        if (Convert.ToBoolean(configuration.GetSection("UseInMemoryDb").Value))
        {
            services.AddDbContext<LinksContext>(options =>
                options.UseInMemoryDatabase("ApplicationDb"));
        }
        else
        {
            services.AddDbContext<LinksContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("LocalDb")
                   //b => b.MigrationsAssembly(typeof(LinksContext).Assembly.FullName)
                   )
               );
        }
    }
}
