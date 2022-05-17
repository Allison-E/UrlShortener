namespace UrlShortener.Application.Wrappers;
public class Response<T>
{
    public T Data { get; set; }
    public string ErrorMessage { get; set; }
}
