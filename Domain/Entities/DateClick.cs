namespace Domain.Entities;

/// <summary>
/// Represents the number of clicks to a link for a specific date.
/// </summary>
public class DateClick
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Clicks { get; set; }
}
