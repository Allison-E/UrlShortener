using MediatR;
using UrlShortener.Application.Interfaces;

namespace UrlShortener.Application.RequestHandlers.Redirects.Query;
public class RedirectToDestinationQuery: IRequest<string>
{
    public string Alias { get; set; }

    internal class RedirectToDestinationQueryHandler : IRequestHandler<RedirectToDestinationQuery, string>
    {
        private ILinksRepo repo;

        public RedirectToDestinationQueryHandler(IRepoManager repoManager)
        {
            repo = repoManager.LinksRepo;
        }

        public Task<string> Handle(RedirectToDestinationQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var link = repo.GetLink(request.Alias);
                return link.Destination;
            });
        }
    }
}
