using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.RequestHandlers.Links.Commands.Create;
using UrlShortener.Application.RequestHandlers.Links.Query;

namespace UrlShortener.Presentation.Controllers;

[Route("links")]
[Produces("application/json")]
public class LinksController : ControllerBase
{
    private IMediator mediator;

    public LinksController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLinkAsync([FromRoute] string id)
    {
        return Ok(await mediator.Send(new GetLinkByAliasQuery { Alias = id }));
    }

    /// <summary>
    /// Creates a shortened link from the given destination URL given.
    /// </summary>
    /// <param name="createLink"></param>
    /// <param name="cancellationToken"></param>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /generate
    ///     {
    ///         "destination": "https://google.com",
    ///         "title": "Google"
    ///     }
    /// </remarks>
    /// <returns>The alias of the shortened URL.</returns>
    [HttpPost("generate")]
    public async Task<IActionResult> GenerateLinkAsync([FromBody] CreateLinkCommand createLink, CancellationToken cancellationToken = default)
    {
        return Ok(await mediator.Send(createLink));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLinkAsync([FromRoute] string id)
    {

    }
}
