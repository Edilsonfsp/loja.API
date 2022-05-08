using Flunt.Notifications;
using loja.API.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace loja.API.Infra.Data;

public class ApplicationDbContext : DbContext
  {
    public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Product>().Property(p => p.Name).IsRequired();
			builder.Entity<Product>().Property(p => p.Description).HasMaxLength(255).IsRequired(false);

			builder.Entity<Category>().Property(c => c.Name).IsRequired();

			builder.Ignore<Notification>();
		}
		protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
		{
			configuration.Properties<string>().HaveMaxLength(100);
		}
  }
