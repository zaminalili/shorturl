namespace shorturl.API.Models.Entities;

public class Url
{
    public int Id { get; set; }
    public string OriginalUrl { get; set; } = default!;
    public string ShortCode { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int AccessCount { get; set; }
}
