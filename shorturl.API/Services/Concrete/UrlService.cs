using AutoMapper;
using shorturl.API.Extensions;
using shorturl.API.Models.Dtos;
using shorturl.API.Models.Entities;
using shorturl.API.Repositories.Abstract;
using shorturl.API.Services.Abstract;

namespace shorturl.API.Services.Concrete;

internal class UrlService(IUrlRepository urlRepository, IMapper mapper): IUrlService
{
    public async Task<GetUrlDto> CreateShortUrl(string originalUrl)
    {
        string shortCode = "";

        do
        {
            shortCode = ShortCodeExtension.GenerateCode(3, 3);
        }
        while (await urlRepository.IsAny(shortCode));


        var url = new Url
        {
            OriginalUrl = originalUrl,
            ShortCode = shortCode,
            CreatedAt = DateTime.UtcNow,
        };

        await urlRepository.CreateAsync(url);


        return mapper.Map<GetUrlDto>(url); ;
    }

    public async Task<GetUrlDto?> GetShortUrl(string shortCode)
    {
        var urlDetail = await urlRepository.GetUrlAsync(shortCode);

        if(urlDetail != null)
            await urlRepository.IncreaseAccessCount(urlDetail);

        var dto = mapper.Map<GetUrlDto?>(urlDetail);

        return dto;
    }

    public async Task<GetUrlDto?> UpdateShortUrl(string shortCode, string originalUrl)
    {
        var urlDetail = await urlRepository.GetUrlAsync(shortCode);
        if(urlDetail == null)
            return null;

        urlDetail.OriginalUrl = originalUrl;
        urlDetail.UpdatedAt = DateTime.UtcNow;
        await urlRepository.UpdateAsync(urlDetail);

        var dto = mapper.Map<GetUrlDto>(urlDetail);
        return dto;
    }

    public async Task<bool> DeleteShortUrl(string shortCode)
    {
        var urlDetail = await urlRepository.GetUrlAsync(shortCode);
        if (urlDetail == null)
            return false;

        await urlRepository.DeleteAsync(urlDetail);
        return true;
    }
}
