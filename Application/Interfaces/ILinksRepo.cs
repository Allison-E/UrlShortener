using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Models;

namespace UrlShortener.Application.Interfaces;
public interface ILinksRepo
{
    Task<bool> SaveLinkAsync(Link link, CancellationToken cancellationToken = default);

    Link GetLink(string alias, CancellationToken cancellationToken = default);
}
