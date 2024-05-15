using Microsoft.EntityFrameworkCore;
using stock_control_api.Models;

namespace FirstApi.DataBase
{
	public class PgContext : DbContext
	{
		public DbSet<ProductModel> Product { get; set; }
		public DbSet<GroupModel> Group { get; set; }
		public DbSet<SupplierModel> Supplier { get; set; }
		public DbSet<CategoryModel> Category { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(@"Host=localhost:5432;Username=postgres;Password=1234;Database=stock-control");
			base.OnConfiguring(optionsBuilder);
		}
	}
};