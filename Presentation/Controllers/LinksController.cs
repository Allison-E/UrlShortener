using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.RequestHandlers.Links.Commands.Create;
using MediatR;

namespace UrlShortener.Presentation.Controllers;

[Route("links")]
public class LinksController: ControllerBase
{
    IMediator mediator;

    public LinksController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("{id}")]
    public Task<IActionResult> GetLink([FromRoute] string id)
    {
        throw new NotImplementedException();
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GenerateLink([FromBody] CreateLinkCommand createLink, CancellationToken cancellationToken = default)
    {
        return Ok(await mediator.Send(createLink));
    }
}
