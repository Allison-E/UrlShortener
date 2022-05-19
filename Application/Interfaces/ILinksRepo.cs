using UrlShortener.Domain.Models;

namespace UrlShortener.Application.Interfaces;
public interface ILinksRepo
{
    Task<bool> SaveAsync(Link link, CancellationToken cancellationToken = default);

    Link Find(string alias);

    Task<bool> DeleteAsync(string alias, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(Link link, CancellationToken cancellationToken = default);
}
