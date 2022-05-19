namespace UrlShortener.Application.Exceptions;

/// <summary>
/// Represents an error that occurs when the operation could not be completed.
/// </summary>
public class UnsuccessfulOperationException: Exception
{
    public UnsuccessfulOperationException(): base("Operation unsuccessful.")
    {
    }

    public UnsuccessfulOperationException(string message): base(message)
    {
    }
}
