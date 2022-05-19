using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using UrlShortener.Domain.Models;
using System.Threading.Tasks;
using UrlShortener.Application.Interfaces;

namespace UrlShortener.Application.RequestHandlers.Links.Query;
public class GetLinkByAliasQuery: IRequest<Link>
{
    public string Alias { get; set; }

    internal class GetLinkByAliasQueryHandler : IRequestHandler<GetLinkByAliasQuery, Link>
    {
        private ILinksRepo repo;

        public GetLinkByAliasQueryHandler(IRepoManager repoManager)
        {
            repo = repoManager.LinksRepo;
        }
        public Task<Link> Handle(GetLinkByAliasQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>  repo.Find(request.Alias));
        }
    }
}
