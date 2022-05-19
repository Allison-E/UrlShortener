using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.Dto.Link;
public class LinkCreateModel
{
    public string Destination { get; set; }
    public string Title { get; set; }
}
