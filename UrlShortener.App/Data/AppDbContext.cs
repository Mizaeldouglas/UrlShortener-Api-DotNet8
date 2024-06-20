using System.Reflection;
using Microsoft.EntityFrameworkCore;
using UrlShortener.App.Models;

namespace UrlShortener.App.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ShortCode> ShortCodes { get; set; }
    public DbSet<OriginalUrl> OriginalUrls { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
