namespace UrlShortener.App.Models;

public class OriginalUrl
{
    public int Id { get; set; }
    public string LongUrl { get; set; } = string.Empty;
    public string ShortCode { get; set; } = string.Empty;
}