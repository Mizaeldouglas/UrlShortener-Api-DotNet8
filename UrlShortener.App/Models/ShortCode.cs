namespace UrlShortener.App.Models;

public class ShortCode
{
    public int ID { get; set; }
    public string Code { get; set; } = string.Empty;
    public int OriginalUrlId { get; set; }
    public OriginalUrl OriginalUrl { get; set; } 
}