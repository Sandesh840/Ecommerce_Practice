using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Alex Explorer", "Embark on thrilling adventures and explore the unknown. Get ready for a journey of a lifetime!", "ADV20239", 110.0, 95.0, 85.0, 90.0, "Adventure Awaits" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Chef Gourmand", 3, "Indulge in a world of gourmet flavors with our carefully crafted recipes. Elevate your culinary skills!", "GD202310", 75.0, 65.0, 55.0, 60.0, "Gourmet Delights Cookbook" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Emma Serene", 1, "Immerse yourself in mindful moments and find peace in the present. Discover the beauty of mindfulness.", "MM202311", 90.0, 80.0, 70.0, 75.0, "Mindfulness Moments" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Artistic Soul", 1, "Unleash your creativity and express yourself through art. Let your imagination run wild!", "AE202312", 85.0, 75.0, 65.0, 70.0, "Artistic Expression" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Fitness Enthusiast", 2, "Achieve your fitness goals and sculpt your body with our comprehensive fitness guide. Be the best version of yourself!", "UFG202313", 70.0, 60.0, 50.0, 55.0, "Ultimate Fitness Guide" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 7, "Mystery Historian", 3, "Solve historical enigmas and uncover hidden truths. An intriguing journey through time awaits!", "HE202314", 95.0, 85.0, 75.0, 80.0, "Historical Enigma" },
                    { 8, "Astronomy Aficionado", 1, "Gaze at the stars and explore the mysteries of the cosmos. Let the wonders of the universe captivate you!", "SD202315", 80.0, 70.0, 60.0, 65.0, "Stargazer's Dream" },
                    { 9, "Green Thumb", 3, "Create your garden oasis with our carefully curated collection of plants and garden decor. Transform your outdoor space!", "GO202316", 120.0, 100.0, 90.0, 95.0, "Garden Oasis Collection" },
                    { 10, "Wellness Warrior", 2, "Kickstart your journey towards a healthier lifestyle with our specially curated starter pack. Embrace wellness!", "HLS202317", 55.0, 45.0, 35.0, 40.0, "Healthy Lifestyle Starter Pack" },
                    { 11, "Sci-Fi Enthusiast", 1, "Embark on an epic science fiction odyssey and explore new worlds. Let your imagination take flight!", "SFO202318", 105.0, 90.0, 80.0, 85.0, "Sci-Fi Odyssey" },
                    { 12, "Film Buff", 3, "Relive the magic of classic movies with this curated collection. Enjoy movie nights like never before!", "CMN202319", 70.0, 60.0, 50.0, 55.0, "Classic Movie Night" },
                    { 13, "Nature Enthusiast", 1, "Capture the beauty of nature with this artistic canvas collection. Bring the outdoors into your home!", "NC202320", 85.0, 75.0, 65.0, 70.0, "Nature's Canvas" },
                    { 14, "Adventure Seeker", 2, "Plan your great escape and discover thrilling adventures. Turn your wanderlust into reality!", "TGE202321", 95.0, 85.0, 75.0, 80.0, "The Great Escape" },
                    { 15, "Spa Lover", 3, "Transform your home into a spa retreat with our soothing spa essentials. Relax, rejuvenate, and unwind!", "SSE202322", 50.0, 40.0, 30.0, 35.0, "Soothing Spa Essentials" },
                    { 16, "Romance Connoisseur", 1, "Indulge in timeless romance with this collection of classic love stories. Let love's magic enchant you!", "TRC202323", 80.0, 70.0, 60.0, 65.0, "Timeless Romance Collection" },
                    { 17, "Yoga Enthusiast", 2, "Find inner peace and balance with our yoga and mindfulness kit. Start your journey towards holistic wellness!", "YMK202324", 65.0, 55.0, 45.0, 50.0, "Yoga and Mindfulness Kit" },
                    { 18, "Fantasy Artisan", 1, "Dive into the world of fantasy with our exquisite art prints set. Let your imagination come alive!", "FAPS202325", 90.0, 80.0, 70.0, 75.0, "Fantasy Art Prints Set" },
                    { 19, "Kitchen Maestro", 3, "Equip your kitchen with our essential cooking utensil starter pack. Cook like a pro and create delicious meals!", "CUSP202326", 75.0, 65.0, 55.0, 60.0, "Cooking Utensil Starter Pack" },
                    { 20, "Tech Enthusiast", 2, "Stay at the cutting edge of technology with our tech innovator's toolkit. Explore and innovate with confidence!", "TIK202327", 110.0, 95.0, 85.0, 90.0, "Tech Innovator's Toolkit" },
                    { 21, "Fashion Maven", 1, "Revamp your wardrobe with our curated fashionista's essentials. Stay stylish and on-trend!", "FWE202328", 120.0, 100.0, 90.0, 95.0, "Fashionista's Wardrobe Essentials" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Nancy Hoover", "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "CAW777777701", 40.0, 30.0, 20.0, 25.0, "Dark Skies" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Julian Button", 1, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "RITO5555501", 55.0, 50.0, 35.0, 40.0, "Vanish in the Sunset" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Abby Muscles", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "WS3333333301", 70.0, 65.0, 55.0, 60.0, "Cotton Candy" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Ron Parker", 2, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SOTJ1111111101", 30.0, 27.0, 20.0, 25.0, "Rock in the Ocean" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { 1, "Billy Spark", 1, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SWD9999001", 99.0, 90.0, 80.0, 85.0, "Fortune of Time" });
        }
    }
}
