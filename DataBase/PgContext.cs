using Microsoft.EntityFrameworkCore;
using stock_control_api.Entities;

namespace stock_control_api.DataBase
{
	public class PgContext : DbContext
	{
		public DbSet<Product> Product { get; set; }
		public DbSet<Group> Group { get; set; }
		public DbSet<Supplier> Supplier { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(@"Host=localhost:5432;Username=postgres;Password=1234;Database=stock-control");
			base.OnConfiguring(optionsBuilder);
		}
	}
};