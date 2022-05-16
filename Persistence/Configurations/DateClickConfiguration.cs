using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Domain.Models;

namespace UrlShortener.Persistence.Configurations;
internal class DateClickConfiguration : IEntityTypeConfiguration<DateClick>
{
    public void Configure(EntityTypeBuilder<DateClick> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Date).HasDefaultValue(DateTime.UtcNow.Date);

        builder.Property(x => x.Clicks).HasDefaultValue(0);

        builder.Property(x => x.Clicks).IsRequired();
    }
}
