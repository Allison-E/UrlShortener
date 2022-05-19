using AutoMapper;
using UrlShortener.Application.Dto.DateClick;
using UrlShortener.Domain.Models;

namespace UrlShortener.Application.Mappings;
internal class DateClickProfile: Profile
{
    public DateClickProfile()
    {
        CreateMap<DateClick, DateClickViewModel>();
    }
}
