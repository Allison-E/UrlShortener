namespace UrlShortener.Application.Wrappers;
public class PagedResponse<T>: Response<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public Uri FirstPage { get; set; }
    public Uri LastPage { get; set; }
    public Uri PreviousPage { get; set; }
    public Uri NextPage { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
}
