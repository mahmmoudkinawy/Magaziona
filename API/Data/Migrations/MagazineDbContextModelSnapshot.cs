﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(MagazineDbContext))]
    partial class MagazineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("API.Entities.ArticleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contents")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("164bee47-ef9f-48c0-b07a-2eb5ad1bb73e"),
                            Contents = "This is content for article 1",
                            Summary = "This is summary for article 1",
                            Title = "Testing bla bla 1"
                        },
                        new
                        {
                            Id = new Guid("5542c0fa-4c3c-4eec-8e18-3ae07883d2b7"),
                            Contents = "This is content for article 2",
                            Summary = "This is summary for article 2",
                            Title = "Testing bla bla 2"
                        },
                        new
                        {
                            Id = new Guid("f9b78da2-b16d-4583-ab45-635f239dbac8"),
                            Contents = "This is content for article 3",
                            Summary = "This is summary for article 3",
                            Title = "Testing bla bla 3"
                        });
                });

            modelBuilder.Entity("API.Entities.ImageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PublishId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("API.Entities.ImageEntity", b =>
                {
                    b.HasOne("API.Entities.ArticleEntity", "ArticleEntity")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArticleEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
