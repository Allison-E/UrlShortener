﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrlShortener.Persistence.Contexts;

#nullable disable

namespace UrlShortener.Persistence.Migrations
{
    [DbContext(typeof(LinksContext))]
    partial class LinksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UrlShortener.Domain.Models.DateClick", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Clicks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc));

                    b.Property<int?>("LinkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LinkId");

                    b.ToTable("DateClicks");
                });

            modelBuilder.Entity("UrlShortener.Domain.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("UrlShortener.Domain.Models.DateClick", b =>
                {
                    b.HasOne("UrlShortener.Domain.Models.Link", null)
                        .WithMany("Clicks")
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UrlShortener.Domain.Models.Link", b =>
                {
                    b.Navigation("Clicks");
                });
#pragma warning restore 612, 618
        }
    }
}
