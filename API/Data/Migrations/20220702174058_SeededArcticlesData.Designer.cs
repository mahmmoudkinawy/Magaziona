﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(MagazineDbContext))]
    [Migration("20220702174058_SeededArcticlesData")]
    partial class SeededArcticlesData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("79e5e9b9-0d98-4616-bf3a-64701cda78d7"),
                            Contents = "This is content for article 1",
                            Summary = "This is summary for article 1",
                            Title = "Testing bla bla 1"
                        },
                        new
                        {
                            Id = new Guid("83ded46f-ddcc-4db4-b9d7-962e7da0357d"),
                            Contents = "This is content for article 2",
                            Summary = "This is summary for article 2",
                            Title = "Testing bla bla 2"
                        },
                        new
                        {
                            Id = new Guid("dd0d715c-abd3-4372-be75-70a72a54fcfa"),
                            Contents = "This is content for article 3",
                            Summary = "This is summary for article 3",
                            Title = "Testing bla bla 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
