using Microsoft.EntityFrameworkCore;
using shorturl.API.Models;
using shorturl.API.Models.Entities;
using shorturl.API.Repositories.Abstract;

namespace shorturl.API.Repositories.Concrete;

internal class UrlRepository(ShorturlDbContext dbContext) : IUrlRepository
{
    public async Task CreateAsync(Url url)
    {
        dbContext.Urls.Add(url);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Url url)
    {
        dbContext.Urls.Remove(url);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Url?> GetUrlAsync(string shortCode)
    {
        return await dbContext.Urls.FirstOrDefaultAsync(u => u.ShortCode == shortCode);
    }

    public async Task UpdateAsync(Url url)
    {
        if (await GetUrlAsync(url.ShortCode) != null)
            dbContext.Urls.Update(url);

        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsAny(string shortCode)
    {
        return await dbContext.Urls.AnyAsync(u => u.ShortCode == shortCode);
    }

    public async Task IncreaseAccessCount(Url url)
    {
        url.AccessCount++;

        await UpdateAsync(url);
    }
}
