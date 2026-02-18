using Microsoft.EntityFrameworkCore;
using V2.Shared.Models;

namespace V2.Shared.Data;

public static class ContentSeedData
{
    public static async Task EnsureSeedDataAsync(ContentDbContext dbContext)
    {
        if (dbContext.Database.IsSqlServer())
        {
            await using var tx = await dbContext.Database.BeginTransactionAsync();

            await dbContext.Database.ExecuteSqlRawAsync(
                "EXEC sp_getapplock @Resource = N'V2.ContentSeed', @LockMode = 'Exclusive', @LockOwner = 'Transaction', @LockTimeout = 15000;");

            await SeedMissingPagesAsync(dbContext);
            await tx.CommitAsync();
            return;
        }

        await SeedMissingPagesAsync(dbContext);
    }

    private static async Task SeedMissingPagesAsync(ContentDbContext dbContext)
    {
        var existingSlugs = await dbContext.PageContents
            .Select(x => x.Slug)
            .ToListAsync();

        var slugSet = existingSlugs
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        var now = DateTime.UtcNow;
        var defaults = new[]
        {
            new PageContent
            {
                Slug = "home",
                Title = "Ana Sayfa",
                Body = "Bu içerik V2 senaryosunda ayrı deploy edilen Site ve Admin uygulamalarıyla yönetilir.",
                UpdatedBy = "System",
                UpdatedAtUtc = now
            },
            new PageContent
            {
                Slug = "about",
                Title = "Hakkımızda",
                Body = "V2, tek repoda iki farklı MVC uygulaması ile CI/CD eğitimi için hazırlanmıştır.",
                UpdatedBy = "System",
                UpdatedAtUtc = now
            },
            new PageContent
            {
                Slug = "contact",
                Title = "İletişim",
                Body = "Bize v2-ornek@firma.com adresinden ulaşabilirsiniz.",
                UpdatedBy = "System",
                UpdatedAtUtc = now
            }
        };

        var newPages = defaults
            .Where(x => !slugSet.Contains(x.Slug))
            .ToList();

        if (newPages.Count == 0)
        {
            return;
        }

        await dbContext.PageContents.AddRangeAsync(newPages);
        await dbContext.SaveChangesAsync();
    }
}
