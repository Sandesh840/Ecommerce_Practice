using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class completemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTotal = table.Column<double>(type: "float", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeader_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_OrderHeader_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Action" },
                    { 2, 2, "History" },
                    { 3, 3, "Art" }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Kathmandu", "Tech Solution", "7853214965", "44500", "3", "Kapan" },
                    { 2, "Khotang", "IT Expert", "74327756375", "6501", "1", "Dhumbaharai" },
                    { 3, "Bhaktapur", "Orchid", "7427785745", "4702", "2", "Gausala" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 2, "Alex Explorer", 2, "Embark on thrilling adventures and explore the unknown. Get ready for a journey of a lifetime! Uncover hidden treasures, face formidable challenges, and triumph over adversity as you traverse uncharted territories. This book is your passport to excitement and discovery.", "ADV20239", 110.0, 95.0, 85.0, 90.0, "Adventure Awaits" },
                    { 3, "Chef Gourmand", 3, "Indulge in a world of gourmet flavors with our carefully crafted recipes. Elevate your culinary skills! From mouth-watering appetizers to decadent desserts, this cookbook offers a tantalizing array of dishes that will impress even the most discerning palates. Get ready to embark on a gastronomic journey like no other.", "GD202310", 75.0, 65.0, 55.0, 60.0, "Gourmet Delights Cookbook" },
                    { 4, "Emma Serene", 1, "Immerse yourself in mindful moments and find peace in the present. Discover the beauty of mindfulness. This guide is your companion to mindfulness, offering practical techniques to achieve tranquility in a chaotic world. Through focused breathing and self-awareness, you can attain a state of serene consciousness that will enhance your overall well-being.", "MM202311", 90.0, 80.0, 70.0, 75.0, "Mindfulness Moments" },
                    { 5, "Artistic Soul", 1, "Unleash your creativity and express yourself through art. Let your imagination run wild! This book is an invitation to explore the realms of artistic expression. Dive into the world of colors, shapes, and textures, and learn various techniques that will help you create awe-inspiring artworks. Discover the artist within you and set your creativity free.", "AE202312", 85.0, 75.0, 65.0, 70.0, "Artistic Expression" },
                    { 6, "Fitness Enthusiast", 2, "Achieve your fitness goals and sculpt your body with our comprehensive fitness guide. Be the best version of yourself! This fitness guide is a roadmap to a healthier, fitter you. Tailored workout plans, nutrition tips, and motivational advice will help you embark on a transformative fitness journey. Take the first step towards a better you.", "UFG202313", 70.0, 60.0, 50.0, 55.0, "Ultimate Fitness Guide" },
                    { 7, "Mystery Historian", 3, "Solve historical enigmas and uncover hidden truths. An intriguing journey through time awaits! Delve into the mysteries of history, decipher clues from the past, and unlock the secrets that have eluded historians for centuries. This book invites you to become a detective of the past, solving enigmas that will unravel fascinating historical narratives.", "HE202314", 95.0, 85.0, 75.0, 80.0, "Historical Enigma" },
                    { 8, "Astronomy Aficionado", 1, "Gaze at the stars and explore the mysteries of the cosmos. Let the wonders of the universe captivate you! In this celestial journey, you'll traverse the vast expanse of space, exploring distant galaxies, nebulae, and the awe-inspiring beauty of our cosmos. With stunning imagery and intriguing facts, this book is your portal to the wonders of the night sky.", "SD202315", 80.0, 70.0, 60.0, 65.0, "Stargazer's Dream" },
                    { 9, "Green Thumb", 3, "Create your garden oasis with our carefully curated collection of plants and garden decor. Transform your outdoor space! Dive into the world of gardening and landscaping with this collection. Discover a variety of plants, decorative elements, and expert tips to turn your garden into a serene oasis. Let your creativity bloom in your own backyard.", "GO202316", 120.0, 100.0, 90.0, 95.0, "Garden Oasis Collection" },
                    { 10, "Wellness Warrior", 2, "Kickstart your journey towards a healthier lifestyle with our specially curated starter pack. Embrace wellness! This starter pack is designed to set you on a path of holistic wellness. It includes essential tools, guides, and motivation to help you adopt a healthy lifestyle. Take charge of your well-being and embrace the journey to a healthier you.", "HLS202317", 55.0, 45.0, 35.0, 40.0, "Healthy Lifestyle Starter Pack" },
                    { 11, "Sci-Fi Enthusiast", 1, "Embark on an epic science fiction odyssey and explore new worlds. Let your imagination take flight! Prepare for an intergalactic adventure in this sci-fi odyssey. Traverse through the cosmos, encounter extraterrestrial beings, and witness futuristic technologies. With gripping narratives and imaginative storytelling, this book will transport you to a realm of infinite possibilities.", "SFO202318", 105.0, 90.0, 80.0, 85.0, "Sci-Fi Odyssey" },
                    { 12, "Film Buff", 3, "Relive the magic of classic movies with this curated collection. Enjoy movie nights like never before! Rediscover timeless cinematic masterpieces with this collection of classic movies. From unforgettable performances to iconic dialogues, these movies have stood the test of time and continue to captivate audiences of all ages.", "CMN202319", 70.0, 60.0, 50.0, 55.0, "Classic Movie Night" },
                    { 13, "Nature Enthusiast", 1, "Capture the beauty of nature with this artistic canvas collection. Bring the outdoors into your home! Immerse yourself in the beauty of nature through this collection of art canvases. Each piece captures the essence of natural landscapes, from serene forests to breathtaking seascapes. Let nature's beauty grace your walls and fill your living space with tranquility.", "NC202320", 85.0, 75.0, 65.0, 70.0, "Nature's Canvas" },
                    { 14, "Adventure Seeker", 2, "Plan your great escape and discover thrilling adventures. Turn your wanderlust into reality! Let your wanderlust take flight with this guide to great escapes. Whether you're dreaming of a tropical paradise, a mountain retreat, or an urban adventure, this book will help you plan the perfect getaway. It's time to turn your travel fantasies into unforgettable memories.", "TGE202321", 95.0, 85.0, 75.0, 80.0, "The Great Escape" },
                    { 15, "Spa Lover", 3, "Transform your home into a spa retreat with our soothing spa essentials. Relax, rejuvenate, and unwind! Create your own sanctuary of relaxation with our spa essentials. From aromatic candles to luxurious bath oils, immerse yourself in a world of tranquility and self-care. Let the stresses of the day melt away as you indulge in a spa-like experience within the comforts of your home.", "SSE202322", 50.0, 40.0, 30.0, 35.0, "Soothing Spa Essentials" },
                    { 16, "Romance Connoisseur", 1, "Indulge in timeless romance with this collection of classic love stories. Let love's magic enchant you! Immerse yourself in a world of passion and romance with this curated collection. These timeless love stories will tug at your heartstrings and transport you to a world where love conquers all. Discover the enchanting tales that have captured the hearts of generations.", "TRC202323", 80.0, 70.0, 60.0, 65.0, "Timeless Romance Collection" },
                    { 17, "Yoga Enthusiast", 2, "Find inner peace and balance with our yoga and mindfulness kit. Start your journey towards holistic wellness! Begin your path to holistic wellness with our yoga and mindfulness kit. Discover the transformative power of yoga and mindfulness practices that nurture your mind, body, and soul. Embrace a lifestyle of serenity and balance.", "YMK202324", 65.0, 55.0, 45.0, 50.0, "Yoga and Mindfulness Kit" },
                    { 18, "Fantasy Artisan", 1, "Dive into the world of fantasy with our exquisite art prints set. Let your imagination come alive! Immerse yourself in a realm of fantasy with this art prints set. Each print showcases fantastical creatures, mythical landscapes, and magical scenes that will transport you to a world beyond imagination. Let your walls tell a story of enchantment and wonder.", "FAPS202325", 90.0, 80.0, 70.0, 75.0, "Fantasy Art Prints Set" },
                    { 19, "Kitchen Maestro", 3, "Equip your kitchen with our essential cooking utensil starter pack. Cook like a pro and create delicious meals! Unleash your inner chef with this cooking utensil starter pack. From spatulas to measuring cups, we've curated the essential tools to elevate your culinary skills. Cook with precision and flair, and delight your taste buds with delectable creations.", "CUSP202326", 75.0, 65.0, 55.0, 60.0, "Cooking Utensil Starter Pack" },
                    { 20, "Tech Enthusiast", 2, "Stay at the cutting edge of technology with our tech innovator's toolkit. Explore and innovate with confidence! Embrace the future with our tech innovator's toolkit. Stay informed about the latest advancements, tools, and technologies that are shaping our world. Equip yourself with the knowledge to innovate, create, and lead in the fast-paced tech landscape.", "TIK202327", 110.0, 95.0, 85.0, 90.0, "Tech Innovator's Toolkit" },
                    { 21, "Fashion Maven", 1, "Revamp your wardrobe with our curated fashionista's essentials. Stay stylish and on-trend! Elevate your style with our fashionista's essentials. From chic apparel to statement accessories, this collection is designed for the trendsetter in you. Stay ahead of the fashion curve and make a statement wherever you go.", "FWE202328", 120.0, 100.0, 90.0, 95.0, "Fashionista's Wardrobe Essentials" },
                    { 22, "Alex Explorer", 2, "Continue your thrilling adventures and explore new territories. The journey of a lifetime continues! Unlock new mysteries and face even greater challenges as you venture into uncharted territories. This sequel to the Adventure Awaits series promises an adrenaline-pumping expedition like no other. Get ready for the next chapter of excitement and discovery.", "ADV20239-2", 115.0, 100.0, 90.0, 95.0, "Adventure Awaits - Part 2" },
                    { 23, "Chef Extraordinaire", 3, "Master the art of cooking with our comprehensive culinary guide. Elevate your skills to a professional level! Take your culinary skills to new heights with this in-depth guide to mastering the art of cooking. From knife techniques to flavor pairings, this book covers everything you need to become a true chef. Let the culinary journey begin!", "MCA202329", 85.0, 75.0, 65.0, 70.0, "Mastering the Culinary Arts" },
                    { 24, "Empowerment Advocate", 1, "Empower women and inspire change with our guide to women's empowerment. Celebrate the strength and resilience of women! This guide is a tribute to the remarkable achievements and contributions of women throughout history. It's a call to action to uplift, support, and empower women in all walks of life. Together, let's create a world where every woman can thrive and succeed.", "EWE202330", 70.0, 60.0, 50.0, 55.0, "Empowering Women's Empowerment" },
                    { 25, "Parenting Guru", 2, "Practice mindful parenting and foster a strong bond with your child. Navigate the joys and challenges of parenthood with awareness! This book is a guide to mindful parenting, providing practical tips and insights to raise emotionally intelligent and resilient children. Cultivate a deeper connection with your child and create a nurturing environment for their growth and development.", "MP202331", 95.0, 85.0, 75.0, 80.0, "Mindful Parenting" },
                    { 26, "Sustainability Advocate", 1, "Embrace eco-friendly living and make a positive impact on the planet. Discover sustainable practices for a greener future! This book is a roadmap to living a more eco-conscious life. Explore sustainable choices, from reducing waste to conserving energy, and learn how small changes can lead to a big difference in preserving our environment. Join the movement for a greener, cleaner planet.", "EFL202332", 80.0, 70.0, 60.0, 65.0, "Eco-Friendly Living" },
                    { 27, "Financial Guru", 3, "Take control of your finances and achieve financial freedom with our comprehensive blueprint. Secure your financial future! This guide is your blueprint to financial independence. Learn key principles of money management, investing, and wealth creation that will empower you to take control of your financial destiny. It's time to build a solid foundation for financial success.", "FFB202333", 100.0, 90.0, 80.0, 85.0, "Financial Freedom Blueprint" },
                    { 28, "Mindfulness Enthusiast", 2, "Immerse yourself in the art of mindful living and find inner peace in the chaos of modern life. Cultivate mindfulness for a harmonious existence! This book is a guide to embracing mindfulness as a way of life. Explore mindfulness practices that will help you live in the present moment, reduce stress, and cultivate a sense of peace and balance in your daily life.", "AML202334", 65.0, 55.0, 45.0, 50.0, "The Art of Mindful Living" },
                    { 29, "Happiness Scholar", 1, "Unlock the secrets to happiness and lead a joyful, fulfilling life. Delve into the science and art of true happiness! This book explores the fascinating science behind happiness and offers actionable insights to help you cultivate happiness in your life. Discover the factors that contribute to a fulfilling life and embark on a journey towards a happier, more meaningful existence.", "SOH202335", 75.0, 65.0, 55.0, 60.0, "The Science of Happiness" },
                    { 30, "Culinary Explorer", 3, "Embark on a global culinary adventure and discover the diverse flavors of world cuisines. Expand your palate and tantalize your taste buds! This book is a gastronomic journey around the world, showcasing the vibrant and diverse flavors of various cuisines. From spicy curries to delicate pastries, immerse yourself in a world of taste sensations and culinary traditions.", "EWC202336", 85.0, 75.0, 65.0, 70.0, "Exploring World Cuisines" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderHeaderId",
                table: "OrderDetail",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeader_ApplicationUserId",
                table: "OrderHeader",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_ApplicationUserId",
                table: "ShoppingCart",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_ProductId",
                table: "ShoppingCart",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OrderHeader");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
