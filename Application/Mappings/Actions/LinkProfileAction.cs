using AutoMapper;
using UrlShortener.Application.Dto.Link;
using UrlShortener.Domain.Models;

namespace UrlShortener.Application.Mappings.Actions;
internal class LinkProfileAction : IMappingAction<Link, LinkViewModel>
{
    public void Process(Link source, LinkViewModel destination, ResolutionContext context)
    {
        destination.TotalClicks = 0;
        foreach (var click in source.Clicks)
        {
            destination.TotalClicks += click.Clicks;
        }
    }
}
