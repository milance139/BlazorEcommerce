using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    public partial class SeedMoreProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageURL", "Price", "Title" },
                values: new object[,]
                {
                    { 4, 2, "Shutter Island is a 2010 American neo-noir psychological thriller film[4] directed by Martin Scorsese and adapted by Laeta Kalogridis, based on the 2003 novel of the same name by Dennis Lehane. Leonardo DiCaprio stars as Deputy U.S. Marshal Edward \"Teddy\" Daniels, who is investigating a psychiatric facility on Shutter Island after one of the patients goes missing. Mark Ruffalo plays his partner and fellow deputy marshal, Ben Kingsley plays the facility's lead psychiatrist, Max von Sydow plays a German doctor, and Michelle Williams plays Daniels' wife.\r\n\r\nReleased on February 19, 2010, Shutter Island received generally positive reviews from critics, was chosen by the National Board of Review as one of the top ten films of 2010, and grossed $295 million worldwide. The film is noted for its soundtrack, which prominently used classical music, such as that of Gustav Mahler, Krzysztof Penderecki, György Ligeti, John Cage, Ingram Marshall, and Max Richter.", "https://upload.wikimedia.org/wikipedia/en/7/76/Shutterislandposter.jpg", 12.99m, "Shutter Island" },
                    { 5, 2, "Centar radnje je mrtvi Deda kojega njegovi unuci, Kizo i Lemi, pokušavaju dovesti do Vršca u vlaku, a da nitko ne primjeti da je mrtav. Suvozači u vagonu su Limeni, diler koji nema srca pa ga zato zovu Limeni. Sa Limenim je i Ana, kćerka narkomanke koju je Limeni dobio kao zalog od narkomanke, baba čiji kofer će \"ubiti” dedu, Đura(ćelavi trgovački putnik), sitni lopov i narkoman, beogradska šminkerica Maja, cura kojoj se Limeni uvaljuje. Zaplet počinje kada na Dedu padne kofer, a suvozači misle da ga je to ubilo. Pošto je policija u vlaku, oni bacaju Dedu kroz prozor. I tu sada počinje potraga za Dedom. Traže ga njegovi unuci, ali i Limeni koji je putem pokupio curu iz vlaka i djevojčica. Limeni ga traži zbog toga jer mu je u vagonu ubacio paketić droge u džep, kada je dolazila policija. Dedu pronalazi Radovan na svojoj električnoj ogradi i misli kako je Dedu ubila struja, pokušava ga namjestiti na susjedovu žicu, ali susjed ga otkriva. Nakon toga oni se isto rješavaju Dede i skrivaju ga u Kletovu hladnjaču na benziskoj. Kada Kole otkriva leš on ga se također pokušava riješiti.", "https://upload.wikimedia.org/wikipedia/sr/thumb/1/1f/Mrtav_ladan.jpg/250px-Mrtav_ladan.jpg", 14.99m, "Mrtav 'ladan" },
                    { 6, 2, "Catch Me If You Can is a 2002 American biographical crime comedy-drama[3] film directed and produced by Steven Spielberg and starring Leonardo DiCaprio and Tom Hanks with Christopher Walken, Martin Sheen, Nathalie Baye, Amy Adams and James Brolin in supporting roles. The screenplay by Jeff Nathanson is based on the semi-autobiographical book of the same name by Frank Abagnale Jr., who claims that before his 19th birthday, he successfully performed cons worth millions of dollars by posing as a Pan American World Airways pilot, a Georgia doctor, and a Louisiana parish prosecutor. The historical truth of his story is heavily disputed.", "https://upload.wikimedia.org/wikipedia/en/thumb/4/4d/Catch_Me_If_You_Can_2002_movie.jpg/220px-Catch_Me_If_You_Can_2002_movie.jpg", 9.99m, "Catch Me If You Can" },
                    { 7, 3, "Assassin's Creed Mirage is a 2023 action-adventure game developed by Ubisoft Bordeaux and published by Ubisoft. The game is the thirteenth major installment in the Assassin's Creed series and the successor to 2020's Assassin's Creed Valhalla. While its historical timeframe precedes that of Valhalla, its modern-day framing story succeeds Valhalla's own. Set in 9th-century Baghdad during the Islamic Golden Age—in particular during the Anarchy at Samarra—the story follows Basim Ibn Ishaq (a character first introduced in Valhalla), a street thief who joins the Hidden Ones to fight for peace and liberty, against the Order of the Ancients,[b] who desire peace through control. The main narrative focuses on Basim's internal struggle between his duties as a Hidden One and his desire to uncover his mysterious past.", "https://upload.wikimedia.org/wikipedia/en/thumb/2/23/Assassin%27s_Creed_Mirage_cover.jpeg/220px-Assassin%27s_Creed_Mirage_cover.jpeg", 42.9m, "Assassin's Creed Mirage" },
                    { 8, 3, "Sid Meier's Civilization VI is a turn-based strategy 4X video game developed by Firaxis Games and published by 2K. The mobile and Nintendo Switch port was published by Aspyr Media. The latest entry into the Civilization series, it was released on Windows and macOS in October 2016, with later ports for Linux in February 2017, iOS in December 2017, Nintendo Switch in November 2018, PlayStation 4 and Xbox One in November 2019, and Android in 2020.", "https://upload.wikimedia.org/wikipedia/en/thumb/3/3b/Civilization_VI_cover_art.jpg/220px-Civilization_VI_cover_art.jpg", 60m, "Civilization VI" },
                    { 9, 3, "Call of Duty: Modern Warfare III is a 2023 first-person shooter video game developed by Sledgehammer Games and published by Activision. It is a sequel to 2022's Modern Warfare II, serving as the third entry in the rebooted Modern Warfare sub-series and the twentieth installment in the overall Call of Duty series. The game was released on November 10, 2023, for PlayStation 4, PlayStation 5, Windows, Xbox One, and Xbox Series X/S.", "https://upload.wikimedia.org/wikipedia/en/f/f6/MWIII_Cover_Art.png", 60m, "Call of Duty: Modern Warfare III " }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
