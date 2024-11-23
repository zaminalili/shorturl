namespace shorturl.API.Models.Dtos;

public class GetUrlDto
{
    public string OriginalUrl { get; set; } = default!;
    public string ShortCode { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int AccessCount { get; set; }

}
