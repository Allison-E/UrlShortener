using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application.Dto.DateClick;

namespace UrlShortener.Application.Dto.Link;
public class LinkViewModel
{
    public string Alias { get; set; }
    public string Title { get; set; }
    public string Destination { get; set; }
    public IEnumerable<DateClickViewModel> Clicks { get; set; }
    public bool IsActive { get;set; }
    public DateTime CreatedAt { get; set; }
    public int TotalClicks { get; set; }
}
