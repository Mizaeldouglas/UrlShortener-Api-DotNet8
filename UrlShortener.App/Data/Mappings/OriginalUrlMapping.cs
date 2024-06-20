using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.App.Models;

namespace UrlShortener.App.Data.Mappings;

public class OriginalUrlMapping: IEntityTypeConfiguration<OriginalUrl>

{
    public void Configure(EntityTypeBuilder<OriginalUrl> builder)
    {
        builder.ToTable("OriginalUrls");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.LongUrl).IsRequired();
        builder.Property(x => x.ShortCode).IsRequired();
    }
}