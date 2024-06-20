using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.App.Models;

namespace UrlShortener.App.Data.Mappings;

public class ShortCodeMapping : IEntityTypeConfiguration<ShortCode>
{
    public void Configure(EntityTypeBuilder<ShortCode> builder)
    {
        builder.ToTable("ShortCodes");
        builder.HasKey(x => x.ID);
        builder.Property(x => x.Code).IsRequired();
        builder.HasIndex(x => x.Code).IsUnique();
        builder.HasOne(x => x.OriginalUrl).WithMany().HasForeignKey(x => x.OriginalUrlId);
    }
}
