using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.RequestHandlers.Redirects.Query;

namespace UrlShortener.Presentation.Controllers;
public class RedirectController : ControllerBase
{
    private IMediator mediator;

    public RedirectController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Redirects the user to the destination of the shortened link.
    /// </summary>
    /// <param name="alias">The alias of the link.</param>
    /// <remarks>
    /// For example, if the destination of /rAG2ZGmW is https://google.com,
    /// the user to Google's homepage.
    /// </remarks>
    /// <returns></returns>
    [HttpGet("{alias}")]
    public async Task<IActionResult> RedirectAsync([FromRoute] string alias)
    {
        return RedirectPermanent(await mediator.Send(new RedirectToDestinationQuery { Alias = alias }));
    }
}
