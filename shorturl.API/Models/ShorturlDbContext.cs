using Microsoft.EntityFrameworkCore;
using shorturl.API.Models.Entities;

namespace shorturl.API.Models;

internal class ShorturlDbContext(DbContextOptions<ShorturlDbContext> options): DbContext (options)
{
    internal DbSet<Url> Urls {  get; set; }
}
