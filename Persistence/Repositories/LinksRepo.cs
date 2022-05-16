using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application.Interfaces;
using UrlShortener.Domain.Models;
using UrlShortener.Persistence.Contexts;

namespace UrlShortener.Persistence.Repositories;
internal class LinksRepo : ILinksRepo
{
    LinksContext context;

    public LinksRepo(LinksContext context)
    {
        this.context = context;
    }

    public async Task<bool> SaveLink(Link link, CancellationToken cancellationToken = default)
    {
        await context.Links.AddAsync(link, cancellationToken);
        return await context.SaveChangesAsync() > 0 ? true : false;
    } 
}
