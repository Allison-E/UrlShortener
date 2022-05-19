using UrlShortener.Domain.Models;

namespace UrlShortener.Application.Interfaces;
public interface ILinksRepo
{
    Task<bool> AddAsync(Link link, CancellationToken cancellationToken = default);

    Link Find(string alias);

    Task<bool> DeleteAsync(string alias, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(Link newLink, CancellationToken cancellationToken = default);
}
