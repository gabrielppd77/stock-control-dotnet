using Microsoft.EntityFrameworkCore;
using stock_control_api.Entities;

namespace stock_control_api.DataBase
{
	public class PgContext : DbContext
	{
		private readonly IConfiguration _configuration;

		public PgContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public DbSet<Product> Product { get; set; }
		public DbSet<Group> Group { get; set; }
		public DbSet<Supplier> Supplier { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = _configuration.GetConnectionString("DefaultConnection");
			if (string.IsNullOrEmpty(connectionString))
			{
				throw new InvalidOperationException("Connection string not found.");
			}
			optionsBuilder.UseNpgsql(connectionString);
			base.OnConfiguring(optionsBuilder);
		}
	}
};