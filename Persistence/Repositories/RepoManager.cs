using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application.Interfaces;
using UrlShortener.Persistence.Contexts;

namespace UrlShortener.Persistence.Repositories;
public class RepoManager : IRepoManager
{
    private Lazy<ILinksRepo> lazyLinksRepo;

    public ILinksRepo LinksRepo => lazyLinksRepo.Value;

    public RepoManager(LinksContext context)
    {
        lazyLinksRepo = new(() => new LinksRepo(context));
    }
}
