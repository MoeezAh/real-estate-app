using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Domain.Models;

namespace RealEstatePortal.Infrastructure
{
	public class RealEstateDbContext : DbContext
	{
		public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : base(options) { }

		public DbSet<Property> Properties { get; set; }
		public DbSet<PropertyImage> PropertyImages { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Favorite> Favorites { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Configure relationships
			modelBuilder.Entity<Favorite>()
				.HasKey(f => f.Id);
			modelBuilder.Entity<Favorite>()
				.HasOne<User>()
				.WithMany(u => u.Favorites)
				.HasForeignKey(f => f.UserId);

			modelBuilder.Entity<PropertyImage>()
				.HasOne(pi => pi.Property)
				.WithMany(p => p.Images)
				.HasForeignKey(pi => pi.PropertyId);

			// Seed 100 properties from major cities in Pakistan
			var cities = new[] { "Karachi", "Lahore", "Islamabad", "Rawalpindi", "Faisalabad", "Multan", "Peshawar", "Quetta", "Sialkot", "Gujranwala" };
			var types = new[] { "Sale", "Rent" };
			var titles = new[] { "Modern Villa", "Luxury Apartment", "Family Home", "Studio Flat", "Commercial Plot", "Farmhouse", "Penthouse", "Townhouse", "Office Space", "Shop" };
			var rnd = new System.Random(42);
			var properties = new List<Property>();
			var images = new List<PropertyImage>();
			for (int i = 1; i <= 100; i++)
			{
				var city = cities[rnd.Next(cities.Length)];
				var type = types[rnd.Next(types.Length)];
				var title = titles[rnd.Next(titles.Length)];
				var price = type == "Sale" ? rnd.Next(5000000, 90000000) : rnd.Next(15000, 350000);
				var bedrooms = rnd.Next(1, 7);
				var bathrooms = rnd.Next(1, 5);
				var carSpots = rnd.Next(0, 3);
				properties.Add(new Property
				{
					Id = i,
					Title = $"{title} in {city}",
					Address = $"{rnd.Next(1, 200)} {city} Road",
					City = city,
					Price = price,
					ListingType = type,
					Bedrooms = bedrooms,
					Bathrooms = bathrooms,
					CarSpots = carSpots,
					Description = $"Spacious {title.ToLower()} located in {city}. Ideal for families and professionals."
				});
				images.Add(new PropertyImage
				{
					Id = i,
					PropertyId = i,
					Url = $"https://source.unsplash.com/600x400/?house,pakistan,{city},{title.Replace(" ", "")}"
				});
			}
			modelBuilder.Entity<Property>().HasData(properties);
			modelBuilder.Entity<PropertyImage>().HasData(images);
		}
	}
}
