﻿using shorturl.API.Models.Entities;

namespace shorturl.API.Repositories.Abstract;

public interface IUrlRepository
{
    Task CreateAsync(Url url);
    Task<Url?> GetUrlAsync(string shortCode);
    Task UpdateAsync(Url url);
    Task DeleteAsync(Url url);
    Task<bool> IsAny(string shortCode);
    Task IncreaseAccessCount(Url url);
}
