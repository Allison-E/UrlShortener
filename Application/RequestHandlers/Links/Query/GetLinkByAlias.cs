using AutoMapper;
using MediatR;
using UrlShortener.Application.Dto.Link;
using UrlShortener.Application.Interfaces;

namespace UrlShortener.Application.RequestHandlers.Links.Query;
public class GetLinkByAliasQuery: IRequest<LinkViewModel>
{
    public string Alias { get; set; }

    internal class GetLinkByAliasQueryHandler : IRequestHandler<GetLinkByAliasQuery, LinkViewModel>
    {
        private ILinksRepo repo;
        private IMapper mapper;

        public GetLinkByAliasQueryHandler(IRepoManager repoManager, IMapper mapper)
        {
            repo = repoManager.LinksRepo;
            this.mapper = mapper;
        }
        public Task<LinkViewModel> Handle(GetLinkByAliasQuery request, CancellationToken cancellationToken)
        {
            var link = repo.Find(request.Alias);
            return Task.Run(() => mapper.Map<LinkViewModel>(link));
        }
    }
}
