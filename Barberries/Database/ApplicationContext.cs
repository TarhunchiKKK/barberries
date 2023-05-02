using Barberries.Models;
using Microsoft.EntityFrameworkCore;

namespace Barberries.Database {
	public class ApplicationContext : DbContext{
		public DbSet<User> Users { get; set; } = null!;
		public DbSet<Category> Categories { get; set; } = null!;	
		public DbSet<Product> Products { get; set; } = null!;

		public ApplicationContext(DbContextOptions<ApplicationContext> options) :
			base(options) {
			Database.EnsureCreated();
		}

		// подключение к PostgreSQL
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=Barberriesdb;Username=postgres;Password=123456");
		}

		public async void AddUser(User user) {
			Users.Add(user);
			await SaveChangesAsync();
		}

		public async void AddProduct(Product product) {
			Products.Add(product);
			await SaveChangesAsync();
		}

		public async void AddCategories(IEnumerable<Category> categories) {
			foreach(Category category in categories) {
				Categories.Add(category);
			}
			await SaveChangesAsync();
		}
	}
}
