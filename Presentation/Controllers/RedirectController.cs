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

    [HttpGet("{id}")]
    public async Task<IActionResult> RedirectAsync([FromRoute] string id)
    {
        return RedirectPermanent(await mediator.Send(new RedirectToDestinationQuery { Alias = id }));
    }
}
