using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using UrlShortener.Application.Interfaces;

namespace UrlShortener.Application.Extensions;
public static class ServicesExtension
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}
