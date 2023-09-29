using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this is needed when using identity user
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "History", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Art", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Tech Solution", StreetAddress = "Kapan", City = "Kathmandu", PostalCode = "44500", State = "3", PhoneNumber = "7853214965" },
                new Company { Id = 2, Name = "IT Expert", StreetAddress = "Dhumbaharai", City = "Khotang", PostalCode = "6501", State = "1", PhoneNumber = "74327756375" },
                new Company { Id = 3, Name = "Orchid", StreetAddress = "Gausala", City = "Bhaktapur", PostalCode = "4702", State = "2", PhoneNumber = "7427785745" }
                );

            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  Id = 2,
                  Title = "Adventure Awaits",
                  Author = "Alex Explorer",
                  Description = "Embark on thrilling adventures and explore the unknown. Get ready for a journey of a lifetime! Uncover hidden treasures, face formidable challenges, and triumph over adversity as you traverse uncharted territories. This book is your passport to excitement and discovery.",
                  ISBN = "ADV20239",
                  ListPrice = 110,
                  Price = 95,
                  Price50 = 90,
                  Price100 = 85,
                  CategoryId = 2
              }, new Product
              {
                  Id = 3,
                  Title = "Gourmet Delights Cookbook",
                  Author = "Chef Gourmand",
                  Description = "Indulge in a world of gourmet flavors with our carefully crafted recipes. Elevate your culinary skills! From mouth-watering appetizers to decadent desserts, this cookbook offers a tantalizing array of dishes that will impress even the most discerning palates. Get ready to embark on a gastronomic journey like no other.",
                  ISBN = "GD202310",
                  ListPrice = 75,
                  Price = 65,
                  Price50 = 60,
                  Price100 = 55,
                  CategoryId = 3
              }, new Product
              {
                  Id = 4,
                  Title = "Mindfulness Moments",
                  Author = "Emma Serene",
                  Description = "Immerse yourself in mindful moments and find peace in the present. Discover the beauty of mindfulness. This guide is your companion to mindfulness, offering practical techniques to achieve tranquility in a chaotic world. Through focused breathing and self-awareness, you can attain a state of serene consciousness that will enhance your overall well-being.",
                  ISBN = "MM202311",
                  ListPrice = 90,
                  Price = 80,
                  Price50 = 75,
                  Price100 = 70,
                  CategoryId = 1
              }, new Product
              {
                  Id = 5,
                  Title = "Artistic Expression",
                  Author = "Artistic Soul",
                  Description = "Unleash your creativity and express yourself through art. Let your imagination run wild! This book is an invitation to explore the realms of artistic expression. Dive into the world of colors, shapes, and textures, and learn various techniques that will help you create awe-inspiring artworks. Discover the artist within you and set your creativity free.",
                  ISBN = "AE202312",
                  ListPrice = 85,
                  Price = 75,
                  Price50 = 70,
                  Price100 = 65,
                  CategoryId = 1
              }, new Product
              {
                  Id = 6,
                  Title = "Ultimate Fitness Guide",
                  Author = "Fitness Enthusiast",
                  Description = "Achieve your fitness goals and sculpt your body with our comprehensive fitness guide. Be the best version of yourself! This fitness guide is a roadmap to a healthier, fitter you. Tailored workout plans, nutrition tips, and motivational advice will help you embark on a transformative fitness journey. Take the first step towards a better you.",
                  ISBN = "UFG202313",
                  ListPrice = 70,
                  Price = 60,
                  Price50 = 55,
                  Price100 = 50,
                  CategoryId = 2
              }, new Product
              {
                  Id = 7,
                  Title = "Historical Enigma",
                  Author = "Mystery Historian",
                  Description = "Solve historical enigmas and uncover hidden truths. An intriguing journey through time awaits! Delve into the mysteries of history, decipher clues from the past, and unlock the secrets that have eluded historians for centuries. This book invites you to become a detective of the past, solving enigmas that will unravel fascinating historical narratives.",
                  ISBN = "HE202314",
                  ListPrice = 95,
                  Price = 85,
                  Price50 = 80,
                  Price100 = 75,
                  CategoryId = 3
              }, new Product
              {
                  Id = 8,
                  Title = "Stargazer's Dream",
                  Author = "Astronomy Aficionado",
                  Description = "Gaze at the stars and explore the mysteries of the cosmos. Let the wonders of the universe captivate you! In this celestial journey, you'll traverse the vast expanse of space, exploring distant galaxies, nebulae, and the awe-inspiring beauty of our cosmos. With stunning imagery and intriguing facts, this book is your portal to the wonders of the night sky.",
                  ISBN = "SD202315",
                  ListPrice = 80,
                  Price = 70,
                  Price50 = 65,
                  Price100 = 60,
                  CategoryId = 1
              }, new Product
              {
                  Id = 9,
                  Title = "Garden Oasis Collection",
                  Author = "Green Thumb",
                  Description = "Create your garden oasis with our carefully curated collection of plants and garden decor. Transform your outdoor space! Dive into the world of gardening and landscaping with this collection. Discover a variety of plants, decorative elements, and expert tips to turn your garden into a serene oasis. Let your creativity bloom in your own backyard.",
                  ISBN = "GO202316",
                  ListPrice = 120,
                  Price = 100,
                  Price50 = 95,
                  Price100 = 90,
                  CategoryId = 3
              }, new Product
              {
                  Id = 10,
                  Title = "Healthy Lifestyle Starter Pack",
                  Author = "Wellness Warrior",
                  Description = "Kickstart your journey towards a healthier lifestyle with our specially curated starter pack. Embrace wellness! This starter pack is designed to set you on a path of holistic wellness. It includes essential tools, guides, and motivation to help you adopt a healthy lifestyle. Take charge of your well-being and embrace the journey to a healthier you.",
                  ISBN = "HLS202317",
                  ListPrice = 55,
                  Price = 45,
                  Price50 = 40,
                  Price100 = 35,
                  CategoryId = 2
              }, new Product
              {
                  Id = 11,
                  Title = "Sci-Fi Odyssey",
                  Author = "Sci-Fi Enthusiast",
                  Description = "Embark on an epic science fiction odyssey and explore new worlds. Let your imagination take flight! Prepare for an intergalactic adventure in this sci-fi odyssey. Traverse through the cosmos, encounter extraterrestrial beings, and witness futuristic technologies. With gripping narratives and imaginative storytelling, this book will transport you to a realm of infinite possibilities.",
                  ISBN = "SFO202318",
                  ListPrice = 105,
                  Price = 90,
                  Price50 = 85,
                  Price100 = 80,
                  CategoryId = 1
              }, new Product
              {
                  Id = 12,
                  Title = "Classic Movie Night",
                  Author = "Film Buff",
                  Description = "Relive the magic of classic movies with this curated collection. Enjoy movie nights like never before! Rediscover timeless cinematic masterpieces with this collection of classic movies. From unforgettable performances to iconic dialogues, these movies have stood the test of time and continue to captivate audiences of all ages.",
                  ISBN = "CMN202319",
                  ListPrice = 70,
                  Price = 60,
                  Price50 = 55,
                  Price100 = 50,
                  CategoryId = 3
              }, new Product
              {
                  Id = 13,
                  Title = "Nature's Canvas",
                  Author = "Nature Enthusiast",
                  Description = "Capture the beauty of nature with this artistic canvas collection. Bring the outdoors into your home! Immerse yourself in the beauty of nature through this collection of art canvases. Each piece captures the essence of natural landscapes, from serene forests to breathtaking seascapes. Let nature's beauty grace your walls and fill your living space with tranquility.",
                  ISBN = "NC202320",
                  ListPrice = 85,
                  Price = 75,
                  Price50 = 70,
                  Price100 = 65,
                  CategoryId = 1
              }, new Product
              {
                  Id = 14,
                  Title = "The Great Escape",
                  Author = "Adventure Seeker",
                  Description = "Plan your great escape and discover thrilling adventures. Turn your wanderlust into reality! Let your wanderlust take flight with this guide to great escapes. Whether you're dreaming of a tropical paradise, a mountain retreat, or an urban adventure, this book will help you plan the perfect getaway. It's time to turn your travel fantasies into unforgettable memories.",
                  ISBN = "TGE202321",
                  ListPrice = 95,
                  Price = 85,
                  Price50 = 80,
                  Price100 = 75,
                  CategoryId = 2
              }, new Product
              {
                  Id = 15,
                  Title = "Soothing Spa Essentials",
                  Author = "Spa Lover",
                  Description = "Transform your home into a spa retreat with our soothing spa essentials. Relax, rejuvenate, and unwind! Create your own sanctuary of relaxation with our spa essentials. From aromatic candles to luxurious bath oils, immerse yourself in a world of tranquility and self-care. Let the stresses of the day melt away as you indulge in a spa-like experience within the comforts of your home.",
                  ISBN = "SSE202322",
                  ListPrice = 50,
                  Price = 40,
                  Price50 = 35,
                  Price100 = 30,
                  CategoryId = 3
              }, new Product
              {
                  Id = 16,
                  Title = "Timeless Romance Collection",
                  Author = "Romance Connoisseur",
                  Description = "Indulge in timeless romance with this collection of classic love stories. Let love's magic enchant you! Immerse yourself in a world of passion and romance with this curated collection. These timeless love stories will tug at your heartstrings and transport you to a world where love conquers all. Discover the enchanting tales that have captured the hearts of generations.",
                  ISBN = "TRC202323",
                  ListPrice = 80,
                  Price = 70,
                  Price50 = 65,
                  Price100 = 60,
                  CategoryId = 1
              }, new Product
              {
                  Id = 17,
                  Title = "Yoga and Mindfulness Kit",
                  Author = "Yoga Enthusiast",
                  Description = "Find inner peace and balance with our yoga and mindfulness kit. Start your journey towards holistic wellness! Begin your path to holistic wellness with our yoga and mindfulness kit. Discover the transformative power of yoga and mindfulness practices that nurture your mind, body, and soul. Embrace a lifestyle of serenity and balance.",
                  ISBN = "YMK202324",
                  ListPrice = 65,
                  Price = 55,
                  Price50 = 50,
                  Price100 = 45,
                  CategoryId = 2
              }, new Product
              {
                  Id = 18,
                  Title = "Fantasy Art Prints Set",
                  Author = "Fantasy Artisan",
                  Description = "Dive into the world of fantasy with our exquisite art prints set. Let your imagination come alive! Immerse yourself in a realm of fantasy with this art prints set. Each print showcases fantastical creatures, mythical landscapes, and magical scenes that will transport you to a world beyond imagination. Let your walls tell a story of enchantment and wonder.",
                  ISBN = "FAPS202325",
                  ListPrice = 90,
                  Price = 80,
                  Price50 = 75,
                  Price100 = 70,
                  CategoryId = 1
              }, new Product
              {
                  Id = 19,
                  Title = "Cooking Utensil Starter Pack",
                  Author = "Kitchen Maestro",
                  Description = "Equip your kitchen with our essential cooking utensil starter pack. Cook like a pro and create delicious meals! Unleash your inner chef with this cooking utensil starter pack. From spatulas to measuring cups, we've curated the essential tools to elevate your culinary skills. Cook with precision and flair, and delight your taste buds with delectable creations.",
                  ISBN = "CUSP202326",
                  ListPrice = 75,
                  Price = 65,
                  Price50 = 60,
                  Price100 = 55,
                  CategoryId = 3
              }, new Product
              {
                  Id = 20,
                  Title = "Tech Innovator's Toolkit",
                  Author = "Tech Enthusiast",
                  Description = "Stay at the cutting edge of technology with our tech innovator's toolkit. Explore and innovate with confidence! Embrace the future with our tech innovator's toolkit. Stay informed about the latest advancements, tools, and technologies that are shaping our world. Equip yourself with the knowledge to innovate, create, and lead in the fast-paced tech landscape.",
                  ISBN = "TIK202327",
                  ListPrice = 110,
                  Price = 95,
                  Price50 = 90,
                  Price100 = 85,
                  CategoryId = 2
              }, new Product
              {
                  Id = 21,
                  Title = "Fashionista's Wardrobe Essentials",
                  Author = "Fashion Maven",
                  Description = "Revamp your wardrobe with our curated fashionista's essentials. Stay stylish and on-trend! Elevate your style with our fashionista's essentials. From chic apparel to statement accessories, this collection is designed for the trendsetter in you. Stay ahead of the fashion curve and make a statement wherever you go.",
                  ISBN = "FWE202328",
                  ListPrice = 120,
                  Price = 100,
                  Price50 = 95,
                  Price100 = 90,
                  CategoryId = 1
              }, new Product
              {
                  Id = 22,
                  Title = "Adventure Awaits - Part 2",
                  Author = "Alex Explorer",
                  Description = "Continue your thrilling adventures and explore new territories. The journey of a lifetime continues! Unlock new mysteries and face even greater challenges as you venture into uncharted territories. This sequel to the Adventure Awaits series promises an adrenaline-pumping expedition like no other. Get ready for the next chapter of excitement and discovery.",
                  ISBN = "ADV20239-2",
                  ListPrice = 115,
                  Price = 100,
                  Price50 = 95,
                  Price100 = 90,
                  CategoryId = 2
              }, new Product
              {
                  Id = 23,
                  Title = "Mastering the Culinary Arts",
                  Author = "Chef Extraordinaire",
                  Description = "Master the art of cooking with our comprehensive culinary guide. Elevate your skills to a professional level! Take your culinary skills to new heights with this in-depth guide to mastering the art of cooking. From knife techniques to flavor pairings, this book covers everything you need to become a true chef. Let the culinary journey begin!",
                  ISBN = "MCA202329",
                  ListPrice = 85,
                  Price = 75,
                  Price50 = 70,
                  Price100 = 65,
                  CategoryId = 3
              }, new Product
              {
                  Id = 24,
                  Title = "Empowering Women's Empowerment",
                  Author = "Empowerment Advocate",
                  Description = "Empower women and inspire change with our guide to women's empowerment. Celebrate the strength and resilience of women! This guide is a tribute to the remarkable achievements and contributions of women throughout history. It's a call to action to uplift, support, and empower women in all walks of life. Together, let's create a world where every woman can thrive and succeed.",
                  ISBN = "EWE202330",
                  ListPrice = 70,
                  Price = 60,
                  Price50 = 55,
                  Price100 = 50,
                  CategoryId = 1
              }, new Product
              {
                  Id = 25,
                  Title = "Mindful Parenting",
                  Author = "Parenting Guru",
                  Description = "Practice mindful parenting and foster a strong bond with your child. Navigate the joys and challenges of parenthood with awareness! This book is a guide to mindful parenting, providing practical tips and insights to raise emotionally intelligent and resilient children. Cultivate a deeper connection with your child and create a nurturing environment for their growth and development.",
                  ISBN = "MP202331",
                  ListPrice = 95,
                  Price = 85,
                  Price50 = 80,
                  Price100 = 75,
                  CategoryId = 2
              }, new Product
              {
                  Id = 26,
                  Title = "Eco-Friendly Living",
                  Author = "Sustainability Advocate",
                  Description = "Embrace eco-friendly living and make a positive impact on the planet. Discover sustainable practices for a greener future! This book is a roadmap to living a more eco-conscious life. Explore sustainable choices, from reducing waste to conserving energy, and learn how small changes can lead to a big difference in preserving our environment. Join the movement for a greener, cleaner planet.",
                  ISBN = "EFL202332",
                  ListPrice = 80,
                  Price = 70,
                  Price50 = 65,
                  Price100 = 60,
                  CategoryId = 1
              }, new Product
              {
                  Id = 27,
                  Title = "Financial Freedom Blueprint",
                  Author = "Financial Guru",
                  Description = "Take control of your finances and achieve financial freedom with our comprehensive blueprint. Secure your financial future! This guide is your blueprint to financial independence. Learn key principles of money management, investing, and wealth creation that will empower you to take control of your financial destiny. It's time to build a solid foundation for financial success.",
                  ISBN = "FFB202333",
                  ListPrice = 100,
                  Price = 90,
                  Price50 = 85,
                  Price100 = 80,
                  CategoryId = 3
              }, new Product
              {
                  Id = 28,
                  Title = "The Art of Mindful Living",
                  Author = "Mindfulness Enthusiast",
                  Description = "Immerse yourself in the art of mindful living and find inner peace in the chaos of modern life. Cultivate mindfulness for a harmonious existence! This book is a guide to embracing mindfulness as a way of life. Explore mindfulness practices that will help you live in the present moment, reduce stress, and cultivate a sense of peace and balance in your daily life.",
                  ISBN = "AML202334",
                  ListPrice = 65,
                  Price = 55,
                  Price50 = 50,
                  Price100 = 45,
                  CategoryId = 2
              }, new Product
              {
                  Id = 29,
                  Title = "The Science of Happiness",
                  Author = "Happiness Scholar",
                  Description = "Unlock the secrets to happiness and lead a joyful, fulfilling life. Delve into the science and art of true happiness! This book explores the fascinating science behind happiness and offers actionable insights to help you cultivate happiness in your life. Discover the factors that contribute to a fulfilling life and embark on a journey towards a happier, more meaningful existence.",
                  ISBN = "SOH202335",
                  ListPrice = 75,
                  Price = 65,
                  Price50 = 60,
                  Price100 = 55,
                  CategoryId = 1
              }, new Product
              {
                  Id = 30,
                  Title = "Exploring World Cuisines",
                  Author = "Culinary Explorer",
                  Description = "Embark on a global culinary adventure and discover the diverse flavors of world cuisines. Expand your palate and tantalize your taste buds! This book is a gastronomic journey around the world, showcasing the vibrant and diverse flavors of various cuisines. From spicy curries to delicate pastries, immerse yourself in a world of taste sensations and culinary traditions.",
                  ISBN = "EWC202336",
                  ListPrice = 85,
                  Price = 75,
                  Price50 = 70,
                  Price100 = 65,
                  CategoryId = 3
              }
               );
        }
    }
}
