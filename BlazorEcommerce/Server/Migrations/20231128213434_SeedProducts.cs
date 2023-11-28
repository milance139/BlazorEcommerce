using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageURL", "Price", "Title" },
                values: new object[] { 1, "The Hunger Games is a series of young adult dystopian novels written by American author Suzanne Collins. The first three novels are part of a trilogy following teenage protagonist Katniss Everdeen, and the fourth book is a prequel set 64 years before the original.", "https://upload.wikimedia.org/wikipedia/en/thumb/3/39/The_Hunger_Games_cover.jpg/220px-The_Hunger_Games_cover.jpg", 11.1m, "The Hunger Games" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageURL", "Price", "Title" },
                values: new object[] { 2, "The Silence of the Lambs is a 1988 psychological horror novel by Thomas Harris. Published August 29, 1988. it is the sequel to Harris's 1981 novel Red Dragon and both novels feature the cannibalistic serial killer and brilliant psychiatrist Dr. Hannibal Lecter. This time, however, he is pitted against FBI trainee Clarice Starling as she works to solve the case of the \"Buffalo Bill\" serial killer.", "https://upload.wikimedia.org/wikipedia/en/thumb/6/62/Silence3.png/220px-Silence3.png", 22.2m, "The Silence of the Lambs" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageURL", "Price", "Title" },
                values: new object[] { 3, "Zodiac is a non-fiction book written by Robert Graysmith about the unsolved serial murders committed by the \"Zodiac Killer\" in San Francisco in the late 1960s and early '70s. Since its initial release in 1986, Zodiac has sold 4 million copies worldwide.[1] Graysmith was a cartoonist for the San Francisco Chronicle and later also wrote Zodiac Unmasked.", "https://upload.wikimedia.org/wikipedia/en/thumb/d/d4/ZodiacGraysmith.jpg/220px-ZodiacGraysmith.jpg", 33.3m, "Zodiac" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
