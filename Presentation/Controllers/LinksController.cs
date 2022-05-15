using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.Presentation.Controllers;

[Route("links")]
public class LinksController: ControllerBase
{
    public LinksController()
    {

    }

    [HttpGet("{id}")]
    public Task<IActionResult> GetLink([FromRoute] string id)
    {
        throw new NotImplementedException();
    }

    [HttpPost("generate")]
    public Task<IActionResult> GenerateLink([FromBody] string url)
    {
        throw new NotImplementedException();
    }
}
