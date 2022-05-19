using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace UrlShortener.Application.Extensions;
public static class ServicesExtension
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
