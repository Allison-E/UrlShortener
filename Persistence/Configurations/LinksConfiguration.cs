using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Domain.Models;

namespace UrlShortener.Persistence.Configurations;
internal class LinksConfiguration : IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Clicks)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Alias).IsRequired();

        builder.Property(x => x.Destination).IsRequired();

        builder.Property(x => x.IsActive).HasDefaultValue(false);

        builder.Property(x => x.CreatedAt).HasDefaultValueSql("getutcdate()");
    }
}
