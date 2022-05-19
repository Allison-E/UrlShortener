using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.RequestHandlers.Links.Commands.Create;
using UrlShortener.Application.RequestHandlers.Links.Commands.Delete;
using UrlShortener.Application.RequestHandlers.Links.Query;
using UrlShortener.Application.Dto.Link;
using UrlShortener.Application.RequestHandlers.Links.Commands.Update;

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
    /// <param name="cancellationToken"></param>
    /// <returns>A <see cref="LinkViewModel"/>.</returns>
    [HttpGet("{alias}", Name = "GetCreatedLink")]
    public async Task<IActionResult> GetLinkAsync([FromRoute] string alias, CancellationToken cancellationToken = default)
    {
        return Ok(await mediator.Send(new GetLinkByAliasQuery { Alias = alias }, cancellationToken));
    }

    /// <summary>
    /// Creates a shortened link from the given destination URL given.
    /// </summary>
    /// <param name="createLink">The link object.</param>
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
    public async Task<IActionResult> GenerateLinkAsync([FromBody] LinkCreateModel createLink, CancellationToken cancellationToken = default)
    {
        var alias = await mediator.Send(new CreateLinkCommand
        {
            Destination = createLink.Destination,
            Title = createLink.Title,
        }, cancellationToken);
        var routeValues = new { alias = alias };
        return CreatedAtRoute("GetCreatedLink", routeValues, alias);
    }

    /// <summary>
    /// Updates a link.
    /// </summary>
    /// <param name="alias">The alias of the link.</param>
    /// <param name="link">Updated link object.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{alias}")]
    public async Task<IActionResult> UpdateLinkAsync([FromRoute] string alias, [FromBody] LinkEditModel link, CancellationToken cancellationToken = default)
    {
        return Ok(await mediator.Send(new UpdateLinkCommand { 
            AliasKey = alias, 
            NewKey = link.Alias, 
            Destination = link.Destination, 
            Title = link.Title
        }, cancellationToken));
    }

    /// <summary>
    /// Deletes a link.
    /// </summary>
    /// <param name="alias">The alias of the link.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{alias}")]
    public async Task<IActionResult> DeleteLinkAsync([FromRoute] string alias, CancellationToken cancellationToken = default)
    {
        return Ok(await mediator.Send(new DeleteLinkByAliasCommand { Alias = alias }, cancellationToken));
    }
}
