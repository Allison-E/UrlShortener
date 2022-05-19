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
        var result = context.Links.Join().Where(x => x.Alias == alias).FirstOrDefault();
        return result;
    }

    public async Task<bool> SaveAsync(Link link, CancellationToken cancellationToken = default)
    {
        await context.Links.AddAsync(link, cancellationToken);
        return await context.SaveChangesAsync(cancellationToken) > 0 ? true : false;
    } 

    public async Task<bool> DeleteAsync(string alias, CancellationToken cancellationToken = default)
    {
        var link = context.Links.Where(x => x.Alias == alias).FirstOrDefault();

        if (link == null)
        {
            // Todo: Throw an exception?
            return false;
        }

        context.Links.Remove(link);
        return await context.SaveChangesAsync(cancellationToken) > 0 ? true : false;
    }

    public async Task<bool> UpdateAsync(Link link, CancellationToken cancellationToken = default)
    {
        context.Update(link);
        return await context.SaveChangesAsync(cancellationToken) > 0 ? true : false;
    }
}
