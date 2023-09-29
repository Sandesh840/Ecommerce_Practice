using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
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
                new Company { Id = 1, Name = "Tech Solution", StreetAddress = "Kapan", City="Kathmandu", PostalCode="44500", State="3", PhoneNumber="7853214965" },
                new Company { Id = 2, Name = "IT Expert", StreetAddress = "Dhumbaharai", City="Khotang", PostalCode="6501", State="1", PhoneNumber="74327756375" },
                new Company { Id = 3, Name = "Orchid", StreetAddress = "Gausala", City="Bhaktapur", PostalCode="4702", State="2", PhoneNumber="7427785745" }               
                );

            modelBuilder.Entity<Product>().HasData(
              new Product

              {
                  Id = 2,
                  Title = "Adventure Awaits",
                  Author = "Alex Explorer",
                  Description = "Embark on thrilling adventures and explore the unknown. Get ready for a journey of a lifetime!",
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
                  Description = "Indulge in a world of gourmet flavors with our carefully crafted recipes. Elevate your culinary skills!",
                  ISBN = "GD202310",
                  ListPrice = 75,
                  Price = 65,
                  Price50 = 60,
                  Price100 = 55,
                  CategoryId = 3
              },
              new Product
              {
                  Id = 4,
                  Title = "Mindfulness Moments",
                  Author = "Emma Serene",
                  Description = "Immerse yourself in mindful moments and find peace in the present. Discover the beauty of mindfulness.",
                  ISBN = "MM202311",
                  ListPrice = 90,
                  Price = 80,
                  Price50 = 75,
                  Price100 = 70,
                  CategoryId = 1
              },
              new Product
              {
                  Id = 5,
                  Title = "Artistic Expression",
                  Author = "Artistic Soul",
                  Description = "Unleash your creativity and express yourself through art. Let your imagination run wild!",
                  ISBN = "AE202312",
                  ListPrice = 85,
                  Price = 75,
                  Price50 = 70,
                  Price100 = 65,
                  CategoryId = 1
              },
              new Product
              {
                  Id = 6,
                  Title = "Ultimate Fitness Guide",
                  Author = "Fitness Enthusiast",
                  Description = "Achieve your fitness goals and sculpt your body with our comprehensive fitness guide. Be the best version of yourself!",
                  ISBN = "UFG202313",
                  ListPrice = 70,
                  Price = 60,
                  Price50 = 55,
                  Price100 = 50,
                  CategoryId = 2
              },
              new Product
              {
                  Id = 7,
                  Title = "Historical Enigma",
                  Author = "Mystery Historian",
                  Description = "Solve historical enigmas and uncover hidden truths. An intriguing journey through time awaits!",
                  ISBN = "HE202314",
                  ListPrice = 95,
                  Price = 85,
                  Price50 = 80,
                  Price100 = 75,
                  CategoryId = 3
              },
              new Product
              {
                  Id = 8,
                  Title = "Stargazer's Dream",
                  Author = "Astronomy Aficionado",
                  Description = "Gaze at the stars and explore the mysteries of the cosmos. Let the wonders of the universe captivate you!",
                  ISBN = "SD202315",
                  ListPrice = 80,
                  Price = 70,
                  Price50 = 65,
                  Price100 = 60,
                  CategoryId = 1
              },
              new Product
              {
                  Id = 9,
                  Title = "Garden Oasis Collection",
                  Author = "Green Thumb",
                  Description = "Create your garden oasis with our carefully curated collection of plants and garden decor. Transform your outdoor space!",
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
                  Description = "Kickstart your journey towards a healthier lifestyle with our specially curated starter pack. Embrace wellness!",
                  ISBN = "HLS202317",
                  ListPrice = 55,
                  Price = 45,
                  Price50 = 40,
                  Price100 = 35,
                  CategoryId = 2
              },
              new Product
              {
                  Id = 11,
                  Title = "Sci-Fi Odyssey",
                  Author = "Sci-Fi Enthusiast",
                  Description = "Embark on an epic science fiction odyssey and explore new worlds. Let your imagination take flight!",
                  ISBN = "SFO202318",
                  ListPrice = 105,
                  Price = 90,
                  Price50 = 85,
                  Price100 = 80,
                  CategoryId = 1
              },
              new Product
              {
                  Id = 12,
                  Title = "Classic Movie Night",
                  Author = "Film Buff",
                  Description = "Relive the magic of classic movies with this curated collection. Enjoy movie nights like never before!",
                  ISBN = "CMN202319",
                  ListPrice = 70,
                  Price = 60,
                  Price50 = 55,
                  Price100 = 50,
                  CategoryId = 3
              },
              new Product
              {
                  Id = 13,
                  Title = "Nature's Canvas",
                  Author = "Nature Enthusiast",
                  Description = "Capture the beauty of nature with this artistic canvas collection. Bring the outdoors into your home!",
                  ISBN = "NC202320",
                  ListPrice = 85,
                  Price = 75,
                  Price50 = 70,
                  Price100 = 65,
                  CategoryId = 1
              },
              new Product
              {
                  Id = 14,
                  Title = "The Great Escape",
                  Author = "Adventure Seeker",
                  Description = "Plan your great escape and discover thrilling adventures. Turn your wanderlust into reality!",
                  ISBN = "TGE202321",
                  ListPrice = 95,
                  Price = 85,
                  Price50 = 80,
                  Price100 = 75,
                  CategoryId = 2
              },
              new Product
              {
                  Id = 15,
                  Title = "Soothing Spa Essentials",
                  Author = "Spa Lover",
                  Description = "Transform your home into a spa retreat with our soothing spa essentials. Relax, rejuvenate, and unwind!",
                  ISBN = "SSE202322",
                  ListPrice = 50,
                  Price = 40,
                  Price50 = 35,
                  Price100 = 30,
                  CategoryId = 3
              },
              new Product
              {
                  Id = 16,
                  Title = "Timeless Romance Collection",
                  Author = "Romance Connoisseur",
                  Description = "Indulge in timeless romance with this collection of classic love stories. Let love's magic enchant you!",
                  ISBN = "TRC202323",
                  ListPrice = 80,
                  Price = 70,
                  Price50 = 65,
                  Price100 = 60,
                  CategoryId = 1
              },
              new Product
              {
                  Id = 17,
                  Title = "Yoga and Mindfulness Kit",
                  Author = "Yoga Enthusiast",
                  Description = "Find inner peace and balance with our yoga and mindfulness kit. Start your journey towards holistic wellness!",
                  ISBN = "YMK202324",
                  ListPrice = 65,
                  Price = 55,
                  Price50 = 50,
                  Price100 = 45,
                  CategoryId = 2
              },
              new Product
              {
                  Id = 18,
                  Title = "Fantasy Art Prints Set",
                  Author = "Fantasy Artisan",
                  Description = "Dive into the world of fantasy with our exquisite art prints set. Let your imagination come alive!",
                  ISBN = "FAPS202325",
                  ListPrice = 90,
                  Price = 80,
                  Price50 = 75,
                  Price100 = 70,
                  CategoryId = 1
              },
              new Product
              {
                  Id = 19,
                  Title = "Cooking Utensil Starter Pack",
                  Author = "Kitchen Maestro",
                  Description = "Equip your kitchen with our essential cooking utensil starter pack. Cook like a pro and create delicious meals!",
                  ISBN = "CUSP202326",
                  ListPrice = 75,
                  Price = 65,
                  Price50 = 60,
                  Price100 = 55,
                  CategoryId = 3
              },
              new Product
              {
                  Id = 20,
                  Title = "Tech Innovator's Toolkit",
                  Author = "Tech Enthusiast",
                  Description = "Stay at the cutting edge of technology with our tech innovator's toolkit. Explore and innovate with confidence!",
                  ISBN = "TIK202327",
                  ListPrice = 110,
                  Price = 95,
                  Price50 = 90,
                  Price100 = 85,
                  CategoryId = 2
              },
              new Product
              {
                  Id = 21,
                  Title = "Fashionista's Wardrobe Essentials",
                  Author = "Fashion Maven",
                  Description = "Revamp your wardrobe with our curated fashionista's essentials. Stay stylish and on-trend!",
                  ISBN = "FWE202328",
                  ListPrice = 120,
                  Price = 100,
                  Price50 = 95,
                  Price100 = 90,
                  CategoryId = 1
              }
               );
        }
    }
}
