using AzureExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureExample.Db
{
	public class KadirDbContext : DbContext
	{
		public KadirDbContext(DbContextOptions<KadirDbContext> options) : base(options) { }

		public DbSet<Product> Products => Set<Product>();
		public DbSet<ProductType> ProductTypes => Set<ProductType>();
		public DbSet<Review> Reviews => Set<Review>();
		public DbSet<ReviewPhoto> ReviewsPhoto => Set<ReviewPhoto>();

	}
}
