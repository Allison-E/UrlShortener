using MediatR;
using UrlShortener.Application.Exceptions;
using UrlShortener.Application.Interfaces;

namespace UrlShortener.Application.RequestHandlers.Links.Commands.Update;
public class UpdateLinkCommand: IRequest
{
    public string AliasKey { get; set; }
    public string NewKey { get; set; }
    public string Destination { get; set; }
    public string Title { get; set; }

    internal class UpdateLinkCommandHandler : IRequestHandler<UpdateLinkCommand>
    {
        ILinksRepo repo;

        public UpdateLinkCommandHandler(IRepoManager repoManager)
        {
            repo = repoManager.LinksRepo;
        }

        public async Task<Unit> Handle(UpdateLinkCommand request, CancellationToken cancellationToken)
        {
            var link = repo.Find(request.AliasKey);

            if (link == null)
                throw new NotFoundException();

            if (request.NewKey != null)
                link.Alias = request.NewKey;
            if (request.Destination != null)
                link.Destination = request.Destination;
            if (request.Title != null)
                link.Title = request.Title;

            if (!await repo.UpdateAsync(link, cancellationToken))
                throw new UnsuccessfulOperationException("The link could not be updated, and it's not your fault.");

            return new Unit(); 
        }
    }
}
