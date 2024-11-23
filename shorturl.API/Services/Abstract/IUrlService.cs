using shorturl.API.Models.Dtos;
using shorturl.API.Models.Entities;

namespace shorturl.API.Services.Abstract;

public interface IUrlService
{
    Task<GetUrlDto> CreateShortUrl(string originalUrl);
    Task<GetUrlDto?> GetShortUrl(string shortCode);
    Task<GetUrlDto?> UpdateShortUrl(string shortCode, string originalUrl);
    Task<bool> DeleteShortUrl(string shortCode);
}
