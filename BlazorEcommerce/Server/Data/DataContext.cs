using BlazorEcommerce.Shared.Models.Entities;

namespace BlazorEcommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductVariant>()
                .HasKey(pv => new { pv.ProductId, pv.ProductTypeId});

            modelBuilder.Entity<CartItem>()
                .HasKey(ci => new { ci.UserId, ci.ProductId, ci.ProductTypeId });

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId, oi.ProductTypeId });

            modelBuilder.Entity<ProductType>().HasData(
                    new ProductType { Id = 1, Name = "Default" },
                    new ProductType { Id = 2, Name = "Paperback" },
                    new ProductType { Id = 3, Name = "E-Book" },
                    new ProductType { Id = 4, Name = "Audiobook" },
                    new ProductType { Id = 5, Name = "Stream" },
                    new ProductType { Id = 6, Name = "Blu-ray" },
                    new ProductType { Id = 7, Name = "VHS" },
                    new ProductType { Id = 8, Name = "PC" },
                    new ProductType { Id = 9, Name = "PlayStation" },
                    new ProductType { Id = 10, Name = "Xbox" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Books",
                    Url = "books"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Movies",
                    Url = "movies"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Video Games",
                    Url = "video-games"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "The Hunger Games",
                    Description = "The Hunger Games is a series of young adult dystopian novels written by American author Suzanne Collins. The first three novels are part of a trilogy following teenage protagonist Katniss Everdeen, and the fourth book is a prequel set 64 years before the original.",
                    ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/3/39/The_Hunger_Games_cover.jpg/220px-The_Hunger_Games_cover.jpg",
                    CategoryId = 1,
                    IsFeatured = true
                },
                new Product
                {
                    Id = 2,
                    Title = "The Silence of the Lambs",
                    Description = "The Silence of the Lambs is a 1988 psychological horror novel by Thomas Harris. Published August 29, 1988. it is the sequel to Harris's 1981 novel Red Dragon and both novels feature the cannibalistic serial killer and brilliant psychiatrist Dr. Hannibal Lecter. This time, however, he is pitted against FBI trainee Clarice Starling as she works to solve the case of the \"Buffalo Bill\" serial killer.",
                    ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/6/62/Silence3.png/220px-Silence3.png",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Title = "Zodiac",
                    Description = "Zodiac is a non-fiction book written by Robert Graysmith about the unsolved serial murders committed by the \"Zodiac Killer\" in San Francisco in the late 1960s and early '70s. Since its initial release in 1986, Zodiac has sold 4 million copies worldwide.[1] Graysmith was a cartoonist for the San Francisco Chronicle and later also wrote Zodiac Unmasked.",
                    ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/d/d4/ZodiacGraysmith.jpg/220px-ZodiacGraysmith.jpg",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 4,
                    Title = "Shutter Island",
                    Description = "Shutter Island is a 2010 American neo-noir psychological thriller film[4] directed by Martin Scorsese and adapted by Laeta Kalogridis, based on the 2003 novel of the same name by Dennis Lehane. Leonardo DiCaprio stars as Deputy U.S. Marshal Edward \"Teddy\" Daniels, who is investigating a psychiatric facility on Shutter Island after one of the patients goes missing. Mark Ruffalo plays his partner and fellow deputy marshal, Ben Kingsley plays the facility's lead psychiatrist, Max von Sydow plays a German doctor, and Michelle Williams plays Daniels' wife.\r\n\r\nReleased on February 19, 2010, Shutter Island received generally positive reviews from critics, was chosen by the National Board of Review as one of the top ten films of 2010, and grossed $295 million worldwide. The film is noted for its soundtrack, which prominently used classical music, such as that of Gustav Mahler, Krzysztof Penderecki, György Ligeti, John Cage, Ingram Marshall, and Max Richter.",
                    ImageURL = "https://upload.wikimedia.org/wikipedia/en/7/76/Shutterislandposter.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 5,
                    Title = "Mrtav 'ladan",
                    Description = "Centar radnje je mrtvi Deda kojega njegovi unuci, Kizo i Lemi, pokušavaju dovesti do Vršca u vlaku, a da nitko ne primjeti da je mrtav. Suvozači u vagonu su Limeni, diler koji nema srca pa ga zato zovu Limeni. Sa Limenim je i Ana, kćerka narkomanke koju je Limeni dobio kao zalog od narkomanke, baba čiji kofer će \"ubiti” dedu, Đura(ćelavi trgovački putnik), sitni lopov i narkoman, beogradska šminkerica Maja, cura kojoj se Limeni uvaljuje. Zaplet počinje kada na Dedu padne kofer, a suvozači misle da ga je to ubilo. Pošto je policija u vlaku, oni bacaju Dedu kroz prozor. I tu sada počinje potraga za Dedom. Traže ga njegovi unuci, ali i Limeni koji je putem pokupio curu iz vlaka i djevojčica. Limeni ga traži zbog toga jer mu je u vagonu ubacio paketić droge u džep, kada je dolazila policija. Dedu pronalazi Radovan na svojoj električnoj ogradi i misli kako je Dedu ubila struja, pokušava ga namjestiti na susjedovu žicu, ali susjed ga otkriva. Nakon toga oni se isto rješavaju Dede i skrivaju ga u Kletovu hladnjaču na benziskoj. Kada Kole otkriva leš on ga se također pokušava riješiti.",
                    ImageURL = "https://upload.wikimedia.org/wikipedia/sr/thumb/1/1f/Mrtav_ladan.jpg/250px-Mrtav_ladan.jpg",
                    CategoryId = 2,
                    IsFeatured = true
                },
                new Product
                {
                    Id = 6,
                    Title = "Catch Me If You Can",
                    Description = "Catch Me If You Can is a 2002 American biographical crime comedy-drama[3] film directed and produced by Steven Spielberg and starring Leonardo DiCaprio and Tom Hanks with Christopher Walken, Martin Sheen, Nathalie Baye, Amy Adams and James Brolin in supporting roles. The screenplay by Jeff Nathanson is based on the semi-autobiographical book of the same name by Frank Abagnale Jr., who claims that before his 19th birthday, he successfully performed cons worth millions of dollars by posing as a Pan American World Airways pilot, a Georgia doctor, and a Louisiana parish prosecutor. The historical truth of his story is heavily disputed.",
                    ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/4/4d/Catch_Me_If_You_Can_2002_movie.jpg/220px-Catch_Me_If_You_Can_2002_movie.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 7,
                    Title = "Assassin's Creed Mirage",
                    Description = "Assassin's Creed Mirage is a 2023 action-adventure game developed by Ubisoft Bordeaux and published by Ubisoft. The game is the thirteenth major installment in the Assassin's Creed series and the successor to 2020's Assassin's Creed Valhalla. While its historical timeframe precedes that of Valhalla, its modern-day framing story succeeds Valhalla's own. Set in 9th-century Baghdad during the Islamic Golden Age—in particular during the Anarchy at Samarra—the story follows Basim Ibn Ishaq (a character first introduced in Valhalla), a street thief who joins the Hidden Ones to fight for peace and liberty, against the Order of the Ancients,[b] who desire peace through control. The main narrative focuses on Basim's internal struggle between his duties as a Hidden One and his desire to uncover his mysterious past.",
                    ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/2/23/Assassin%27s_Creed_Mirage_cover.jpeg/220px-Assassin%27s_Creed_Mirage_cover.jpeg",
                    CategoryId = 3
                },
                new Product
                {
                    Id = 8,
                    Title = "Civilization VI",
                    Description = "Sid Meier's Civilization VI is a turn-based strategy 4X video game developed by Firaxis Games and published by 2K. The mobile and Nintendo Switch port was published by Aspyr Media. The latest entry into the Civilization series, it was released on Windows and macOS in October 2016, with later ports for Linux in February 2017, iOS in December 2017, Nintendo Switch in November 2018, PlayStation 4 and Xbox One in November 2019, and Android in 2020.",
                    ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/3/3b/Civilization_VI_cover_art.jpg/220px-Civilization_VI_cover_art.jpg",
                    CategoryId = 3,
                    IsFeatured = true
                },
                new Product
                {
                    Id = 9,
                    Title = "Call of Duty: Modern Warfare III ",
                    Description = "Call of Duty: Modern Warfare III is a 2023 first-person shooter video game developed by Sledgehammer Games and published by Activision. It is a sequel to 2022's Modern Warfare II, serving as the third entry in the rebooted Modern Warfare sub-series and the twentieth installment in the overall Call of Duty series. The game was released on November 10, 2023, for PlayStation 4, PlayStation 5, Windows, Xbox One, and Xbox Series X/S.",
                    ImageURL = "https://upload.wikimedia.org/wikipedia/en/f/f6/MWIII_Cover_Art.png",
                    CategoryId = 3
                }
            );

            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 2,
                    Price = 9.99m,
                    OriginalPrice = 19.99m
                },
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 3,
                    Price = 7.99m
                },
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 4,
                    Price = 19.99m,
                    OriginalPrice = 29.99m
                },
                new ProductVariant
                {
                    ProductId = 2,
                    ProductTypeId = 2,
                    Price = 7.99m,
                    OriginalPrice = 14.99m
                },
                new ProductVariant
                {
                    ProductId = 3,
                    ProductTypeId = 2,
                    Price = 6.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 5,
                    Price = 3.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 6,
                    Price = 9.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 7,
                    Price = 19.99m
                },
                new ProductVariant
                {
                    ProductId = 5,
                    ProductTypeId = 5,
                    Price = 3.99m,
                },
                new ProductVariant
                {
                    ProductId = 6,
                    ProductTypeId = 5,
                    Price = 2.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 8,
                    Price = 29.99m,
                    OriginalPrice = 49.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 9,
                    Price = 49.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 10,
                    Price = 39.99m,
                    OriginalPrice = 49.99m
                },
                new ProductVariant
                {
                    ProductId = 8,
                    ProductTypeId = 8,
                    Price = 49.99m,
                    OriginalPrice = 24.99m,
                },
                new ProductVariant
                {
                    ProductId = 9,
                    ProductTypeId = 8,
                    Price = 60m
                }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
