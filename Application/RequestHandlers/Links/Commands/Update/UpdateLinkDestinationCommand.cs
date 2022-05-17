using MediatR;
using UrlShortener.Domain.Models;

namespace UrlShortener.Application.RequestHandlers.Links.Commands.Update;
public class UpdateLinkDestinationCommand: IRequest<Link>
{
    internal class UpdateLinkDestinationCommandHandler : IRequestHandler<UpdateLinkDestinationCommand, Link>
    {
        public Task<Link> Handle(UpdateLinkDestinationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
