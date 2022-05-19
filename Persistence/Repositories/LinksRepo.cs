using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Exceptions;
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

    public Link Find(string alias)
    {
        var result = context.Links
            .Where(x => x.Alias == alias)
            .Include(x => x.Clicks)
            .FirstOrDefault();

        if (result == null)
            throw new NotFoundException($"Link not found.");

        return result;
    }

    public async Task<bool> AddAsync(Link link, CancellationToken cancellationToken = default)
    {
        await context.Links.AddAsync(link, cancellationToken);
        return await context.SaveChangesAsync(cancellationToken) > 0 ? true : false;
    } 

    public async Task<bool> DeleteAsync(string alias, CancellationToken cancellationToken = default)
    {
        var link = context.Links.Where(x => x.Alias == alias).FirstOrDefault();

        if (link == null)
            throw new NotFoundException($"Link with alias: {alias} not found.");

        context.Links.Remove(link);
        return await context.SaveChangesAsync(cancellationToken) > 0 ? true : false;
    }

    public async Task<bool> UpdateAsync(Link updatedLink, CancellationToken cancellationToken = default)
    {
        context.Entry(updatedLink).State = EntityState.Modified;
        return await context.SaveChangesAsync(cancellationToken) > 0 ? true : false;
    }
}
