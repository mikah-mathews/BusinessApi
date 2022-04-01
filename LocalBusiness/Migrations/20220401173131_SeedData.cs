using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalBusiness.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "BusinessId", "Address", "GoodsType", "Hours", "Name", "PhoneNumber", "Website" },
                values: new object[,]
                {
                    { 1, "853 Leonor Points, HipolitoFurt, IL 83006", "Apparel", "9am to 5pm", "Matilda's Dresses", 2278656128L, "matildasdresses.com" },
                    { 2, "949 Schroeder Meadow, Kirkland, WA 98052", "Fossils", "10am to 8pm", "Rexie's Fossils", 5383392548L, "rexiesfossils.com" },
                    { 3, "64347 Jake Bypass, East Garretfort, TX 70158", "Outdoor recreation", "10am to 9pm", "Miranda's Outdoor Gear", 7898901979L, "mirandasoutdoors.com" },
                    { 4, "2101 Hermina Plaza Suite 649, Braedenland, WA 86302", "Tea", "6am to 5pm", "Pip and Squeak", 5034968358L, "pipandsqueaktea.com" },
                    { 5, "394 Alford Station, East Chanel, CT 64520", "Books", "9am to 9pm", "Bartholomew's Books", 3086879381L, "bartsbooksandcomics.com" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "BusinessId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "BusinessId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "BusinessId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "BusinessId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "BusinessId",
                keyValue: 5);
        }
    }
}
