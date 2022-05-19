using MediatR;
using UrlShortener.Application.Interfaces;
using UrlShortener.Domain.Models;

namespace UrlShortener.Application.RequestHandlers.Redirects.Query;
public class RedirectToDestinationQuery : IRequest<string>
{
    public string Alias { get; set; }

    internal class RedirectToDestinationQueryHandler : IRequestHandler<RedirectToDestinationQuery, string>
    {
        private ILinksRepo repo;

        public RedirectToDestinationQueryHandler(IRepoManager repoManager)
        {
            repo = repoManager.LinksRepo;
        }

        public Task<string> Handle(RedirectToDestinationQuery request, CancellationToken cancellationToken)
        {
            var link = repo.Find(request.Alias);
            Task.Run(() => UpdateDateClick(link));

            return Task.Run(() =>
            {
                return link.Destination;
            });
        }

        private void UpdateDateClick(Link link)
        {
            if (link.Clicks == null)
            {
                DateClick click = new()
                {
                    Clicks = 1,
                    Date = DateTime.UtcNow.Date,
                };

                List<DateClick> clicks = new();
                clicks.Add(click);

                link.Clicks = clicks;
            }
            else
            { 
                // If counts for the date already exists.
                var clickForToday = link.Clicks.Where(x => x.Date.Equals(DateTime.UtcNow.Date)).First();
                if (clickForToday != null)
                {
                    clickForToday.Clicks++;
                }
                else
                {
                    link.Clicks.Append(new DateClick() { Clicks = 1, Date = DateTime.UtcNow.Date });
                }

            }
            
            repo.UpdateAsync(link);
        }
    }
}
