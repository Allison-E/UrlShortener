namespace UrlShortener.Application.Exceptions;

/// <summary>
/// Represents errors that occur when a requested resource is not found.
/// </summary>
public class NotFoundException: Exception
{
    public NotFoundException(): base("Resource not found.")
    {
    }

    public NotFoundException(string message): base (message)
    {
    }
}
