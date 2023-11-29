﻿// <auto-generated />
using System;
using BlazorEcommerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231129112412_SeedMoreProducts")]
    partial class SeedMoreProducts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorEcommerce.Shared.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Books",
                            Url = "books"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Movies",
                            Url = "movies"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Video Games",
                            Url = "video-games"
                        });
                });

            modelBuilder.Entity("BlazorEcommerce.Shared.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

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

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "The Hunger Games is a series of young adult dystopian novels written by American author Suzanne Collins. The first three novels are part of a trilogy following teenage protagonist Katniss Everdeen, and the fourth book is a prequel set 64 years before the original.",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/3/39/The_Hunger_Games_cover.jpg/220px-The_Hunger_Games_cover.jpg",
                            Price = 11.1m,
                            Title = "The Hunger Games"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "The Silence of the Lambs is a 1988 psychological horror novel by Thomas Harris. Published August 29, 1988. it is the sequel to Harris's 1981 novel Red Dragon and both novels feature the cannibalistic serial killer and brilliant psychiatrist Dr. Hannibal Lecter. This time, however, he is pitted against FBI trainee Clarice Starling as she works to solve the case of the \"Buffalo Bill\" serial killer.",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/6/62/Silence3.png/220px-Silence3.png",
                            Price = 22.2m,
                            Title = "The Silence of the Lambs"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Zodiac is a non-fiction book written by Robert Graysmith about the unsolved serial murders committed by the \"Zodiac Killer\" in San Francisco in the late 1960s and early '70s. Since its initial release in 1986, Zodiac has sold 4 million copies worldwide.[1] Graysmith was a cartoonist for the San Francisco Chronicle and later also wrote Zodiac Unmasked.",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/d/d4/ZodiacGraysmith.jpg/220px-ZodiacGraysmith.jpg",
                            Price = 33.3m,
                            Title = "Zodiac"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Shutter Island is a 2010 American neo-noir psychological thriller film[4] directed by Martin Scorsese and adapted by Laeta Kalogridis, based on the 2003 novel of the same name by Dennis Lehane. Leonardo DiCaprio stars as Deputy U.S. Marshal Edward \"Teddy\" Daniels, who is investigating a psychiatric facility on Shutter Island after one of the patients goes missing. Mark Ruffalo plays his partner and fellow deputy marshal, Ben Kingsley plays the facility's lead psychiatrist, Max von Sydow plays a German doctor, and Michelle Williams plays Daniels' wife.\r\n\r\nReleased on February 19, 2010, Shutter Island received generally positive reviews from critics, was chosen by the National Board of Review as one of the top ten films of 2010, and grossed $295 million worldwide. The film is noted for its soundtrack, which prominently used classical music, such as that of Gustav Mahler, Krzysztof Penderecki, György Ligeti, John Cage, Ingram Marshall, and Max Richter.",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/7/76/Shutterislandposter.jpg",
                            Price = 12.99m,
                            Title = "Shutter Island"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Centar radnje je mrtvi Deda kojega njegovi unuci, Kizo i Lemi, pokušavaju dovesti do Vršca u vlaku, a da nitko ne primjeti da je mrtav. Suvozači u vagonu su Limeni, diler koji nema srca pa ga zato zovu Limeni. Sa Limenim je i Ana, kćerka narkomanke koju je Limeni dobio kao zalog od narkomanke, baba čiji kofer će \"ubiti” dedu, Đura(ćelavi trgovački putnik), sitni lopov i narkoman, beogradska šminkerica Maja, cura kojoj se Limeni uvaljuje. Zaplet počinje kada na Dedu padne kofer, a suvozači misle da ga je to ubilo. Pošto je policija u vlaku, oni bacaju Dedu kroz prozor. I tu sada počinje potraga za Dedom. Traže ga njegovi unuci, ali i Limeni koji je putem pokupio curu iz vlaka i djevojčica. Limeni ga traži zbog toga jer mu je u vagonu ubacio paketić droge u džep, kada je dolazila policija. Dedu pronalazi Radovan na svojoj električnoj ogradi i misli kako je Dedu ubila struja, pokušava ga namjestiti na susjedovu žicu, ali susjed ga otkriva. Nakon toga oni se isto rješavaju Dede i skrivaju ga u Kletovu hladnjaču na benziskoj. Kada Kole otkriva leš on ga se također pokušava riješiti.",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/sr/thumb/1/1f/Mrtav_ladan.jpg/250px-Mrtav_ladan.jpg",
                            Price = 14.99m,
                            Title = "Mrtav 'ladan"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "Catch Me If You Can is a 2002 American biographical crime comedy-drama[3] film directed and produced by Steven Spielberg and starring Leonardo DiCaprio and Tom Hanks with Christopher Walken, Martin Sheen, Nathalie Baye, Amy Adams and James Brolin in supporting roles. The screenplay by Jeff Nathanson is based on the semi-autobiographical book of the same name by Frank Abagnale Jr., who claims that before his 19th birthday, he successfully performed cons worth millions of dollars by posing as a Pan American World Airways pilot, a Georgia doctor, and a Louisiana parish prosecutor. The historical truth of his story is heavily disputed.",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/4/4d/Catch_Me_If_You_Can_2002_movie.jpg/220px-Catch_Me_If_You_Can_2002_movie.jpg",
                            Price = 9.99m,
                            Title = "Catch Me If You Can"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Description = "Assassin's Creed Mirage is a 2023 action-adventure game developed by Ubisoft Bordeaux and published by Ubisoft. The game is the thirteenth major installment in the Assassin's Creed series and the successor to 2020's Assassin's Creed Valhalla. While its historical timeframe precedes that of Valhalla, its modern-day framing story succeeds Valhalla's own. Set in 9th-century Baghdad during the Islamic Golden Age—in particular during the Anarchy at Samarra—the story follows Basim Ibn Ishaq (a character first introduced in Valhalla), a street thief who joins the Hidden Ones to fight for peace and liberty, against the Order of the Ancients,[b] who desire peace through control. The main narrative focuses on Basim's internal struggle between his duties as a Hidden One and his desire to uncover his mysterious past.",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/2/23/Assassin%27s_Creed_Mirage_cover.jpeg/220px-Assassin%27s_Creed_Mirage_cover.jpeg",
                            Price = 42.9m,
                            Title = "Assassin's Creed Mirage"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Description = "Sid Meier's Civilization VI is a turn-based strategy 4X video game developed by Firaxis Games and published by 2K. The mobile and Nintendo Switch port was published by Aspyr Media. The latest entry into the Civilization series, it was released on Windows and macOS in October 2016, with later ports for Linux in February 2017, iOS in December 2017, Nintendo Switch in November 2018, PlayStation 4 and Xbox One in November 2019, and Android in 2020.",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/3/3b/Civilization_VI_cover_art.jpg/220px-Civilization_VI_cover_art.jpg",
                            Price = 60m,
                            Title = "Civilization VI"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Description = "Call of Duty: Modern Warfare III is a 2023 first-person shooter video game developed by Sledgehammer Games and published by Activision. It is a sequel to 2022's Modern Warfare II, serving as the third entry in the rebooted Modern Warfare sub-series and the twentieth installment in the overall Call of Duty series. The game was released on November 10, 2023, for PlayStation 4, PlayStation 5, Windows, Xbox One, and Xbox Series X/S.",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/f/f6/MWIII_Cover_Art.png",
                            Price = 60m,
                            Title = "Call of Duty: Modern Warfare III "
                        });
                });

            modelBuilder.Entity("BlazorEcommerce.Shared.Models.Entities.Product", b =>
                {
                    b.HasOne("BlazorEcommerce.Shared.Models.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
