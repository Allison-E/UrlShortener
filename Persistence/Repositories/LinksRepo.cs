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

    public Link GetLink(string alias, CancellationToken cancellationToken = default)
    {
        var result = context.Links.Where(x => x.Alias == alias).FirstOrDefault();
        return result;
    }

    public async Task<bool> SaveLinkAsync(Link link, CancellationToken cancellationToken = default)
    {
        await context.Links.AddAsync(link, cancellationToken);
        return await context.SaveChangesAsync() > 0 ? true : false;
    } 

    public async Task<bool> DeleteLinkAsync(string alias, CancellationToken cancellationToken = default)
    {
        var link = context.Links.Where(x => x.Alias == alias).FirstOrDefault();

        if (link == null)
        {
            // Todo: Throw an exception?
            return false;
        }

        context.Links.Remove(link);
        return await context.SaveChangesAsync() > 0 ? true : false;
    }
}
