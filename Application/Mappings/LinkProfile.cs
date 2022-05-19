using AutoMapper;
using UrlShortener.Application.Dto.Link;
using UrlShortener.Application.Mappings.Actions;
using UrlShortener.Domain.Models;

namespace UrlShortener.Application.Mappings;
internal class LinkProfile: Profile
{
    public LinkProfile()
    {
        CreateMap<Link, LinkViewModel>().AfterMap<LinkProfileAction>();
    }
}
