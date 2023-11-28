﻿// <auto-generated />
using System;
using BlazorEcommerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorEcommerce.Shared.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The Hunger Games is a series of young adult dystopian novels written by American author Suzanne Collins. The first three novels are part of a trilogy following teenage protagonist Katniss Everdeen, and the fourth book is a prequel set 64 years before the original.",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/3/39/The_Hunger_Games_cover.jpg/220px-The_Hunger_Games_cover.jpg",
                            Price = 11.1m,
                            Title = "The Hunger Games"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The Silence of the Lambs is a 1988 psychological horror novel by Thomas Harris. Published August 29, 1988. it is the sequel to Harris's 1981 novel Red Dragon and both novels feature the cannibalistic serial killer and brilliant psychiatrist Dr. Hannibal Lecter. This time, however, he is pitted against FBI trainee Clarice Starling as she works to solve the case of the \"Buffalo Bill\" serial killer.",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/6/62/Silence3.png/220px-Silence3.png",
                            Price = 22.2m,
                            Title = "The Silence of the Lambs"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Zodiac is a non-fiction book written by Robert Graysmith about the unsolved serial murders committed by the \"Zodiac Killer\" in San Francisco in the late 1960s and early '70s. Since its initial release in 1986, Zodiac has sold 4 million copies worldwide.[1] Graysmith was a cartoonist for the San Francisco Chronicle and later also wrote Zodiac Unmasked.",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/d/d4/ZodiacGraysmith.jpg/220px-ZodiacGraysmith.jpg",
                            Price = 33.3m,
                            Title = "Zodiac"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
