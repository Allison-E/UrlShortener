namespace UrlShortener.Domain.Models;
public class Link: BaseEntity
{
    /// <summary>
    /// This is unique for every shortened url and would be used for redirection.
    /// </summary>
    public string Alias { get; set; }

    public string Title { get; set; }

    public string Destination { get; set; }

    public IEnumerable<DateClick> Clicks { get; set; }

    //public int ClickCount
    //{
    //    get
    //    {
    //        if (Clicks == null || Clicks.Count() == 0)
    //            return 0;

    //        int total = 0;
    //        foreach (var click in Clicks)
    //        {
    //            total += click.Clicks;
    //        }
    //        return total;
    //    }
    //}

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
}
