namespace UrlShortener.Domain.Models;

/// <summary>
/// Represents the number of clicks to a link for a specific date.
/// </summary>
public class DateClick: BaseEntity
{
    public DateTime Date { get; set; }
    public int Clicks { get; set; }
}
