using Microsoft.EntityFrameworkCore;
using V2.Shared.Models;

namespace V2.Shared.Data;

public class ContentDbContext(DbContextOptions<ContentDbContext> options) : DbContext(options)
{
    public DbSet<PageContent> PageContents => Set<PageContent>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PageContent>()
            .HasIndex(x => x.Slug)
            .IsUnique();
    }
}
