using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Models;

namespace UrlShortener.Persistence.Contexts;

public class LinksContext : DbContext
{
    public DbSet<Link> Links { get; set; }

    public LinksContext(DbContextOptions<LinksContext> dbContextOptions) : base(dbContextOptions)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LinksContext).Assembly);
    }
}
