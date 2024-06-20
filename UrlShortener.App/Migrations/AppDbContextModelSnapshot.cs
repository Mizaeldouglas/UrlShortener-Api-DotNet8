﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrlShortener.App.Data;

#nullable disable

namespace UrlShortener.App.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("UrlShortener.App.Models.OriginalUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LongUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OriginalUrls", (string)null);
                });

            modelBuilder.Entity("UrlShortener.App.Models.ShortCode", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OriginalUrlId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("OriginalUrlId");

                    b.ToTable("ShortCodes", (string)null);
                });

            modelBuilder.Entity("UrlShortener.App.Models.ShortCode", b =>
                {
                    b.HasOne("UrlShortener.App.Models.OriginalUrl", "OriginalUrl")
                        .WithMany()
                        .HasForeignKey("OriginalUrlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OriginalUrl");
                });
#pragma warning restore 612, 618
        }
    }
}