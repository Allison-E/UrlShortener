using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.RequestHandlers.Links.Commands.Create;
using UrlShortener.Application.RequestHandlers.Links.Commands.Delete;
using UrlShortener.Application.RequestHandlers.Links.Query;

namespace UrlShortener.Presentation.Controllers;

[Route("[controller]")]
[Produces("application/json")]
public class LinksController : ControllerBase
{
    private IMediator mediator;

    public LinksController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Gets the details of a link.
    /// </summary>
    /// <param name="alias">The alias of the link.</param>
    /// <returns>A link object.</returns>
    [HttpGet("{alias}", Name = "GetCreatedLink")]
    public async Task<IActionResult> GetLinkAsync([FromRoute] string alias)
    {
        return Ok(await mediator.Send(new GetLinkByAliasQuery { Alias = alias }));
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
        var alias = await mediator.Send(createLink);
        var routeValues = new { alias = alias };
        return CreatedAtRoute("GetCreatedLink", routeValues, alias);
    }

    /// <summary>
    /// Deletes a link.
    /// </summary>
    /// <param name="alias">The alias of the link.</param>
    /// <returns></returns>
    [HttpDelete("{alias}")]
    public async Task<IActionResult> DeleteLinkAsync([FromRoute] string alias)
    {
        return Ok(await mediator.Send(new DeleteLinkByAliasCommand { Alias = alias }));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLinkDestinationAsync([FromBody] string destination)
    {
        throw new NotImplementedException();
    }
}
