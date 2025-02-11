
using Microsoft.EntityFrameworkCore;
using shorturl.API.Models;

namespace shorturl.API.Tasks;

internal class MigrationRunner(ShorturlDbContext context) : IMigrationRunner
{
    public async Task MigrateAsync()
    {
        if (context.Database.GetPendingMigrations().Any())
        {
            await context.Database.MigrateAsync();
        }
    }
}
