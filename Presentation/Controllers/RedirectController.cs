using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.Presentation.Controllers;
public class RedirectController: ControllerBase
{
    [HttpGet("{id}")]
    public Task<IActionResult> Redirect([FromRoute] string id)
    {
        throw new NotImplementedException();
    }
}
