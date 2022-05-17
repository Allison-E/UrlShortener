using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application.Interfaces;
using MediatR;

namespace UrlShortener.Application.RequestHandlers.Links.Commands.Delete;
public class DeleteLinkByAliasCommand: IRequest
{
    public string Alias { get; set; }
    internal class DeleteLinkByAliasCommandHandler : IRequestHandler<DeleteLinkByAliasCommand>
    {
        private ILinksRepo repo;

        public DeleteLinkByAliasCommandHandler(IRepoManager repoManager)
        {
            repo = repoManager.LinksRepo;
        }

        public async Task<Unit> Handle(DeleteLinkByAliasCommand request, CancellationToken cancellationToken)
        {
            return await repo.DeleteLinkAsync(request.Alias, cancellationToken) ? new Unit() : throw new Exception("Error, error");
        }
    }
}
