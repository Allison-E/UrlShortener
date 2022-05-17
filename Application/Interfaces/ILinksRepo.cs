using UrlShortener.Domain.Models;

namespace UrlShortener.Application.Interfaces;
public interface ILinksRepo
{
    Task<bool> SaveLinkAsync(Link link, CancellationToken cancellationToken = default);

    Link GetLink(string alias, CancellationToken cancellationToken = default);

    Task<bool> DeleteLinkAsync(string alias, CancellationToken cancellationToken = default);
}
