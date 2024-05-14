using Microsoft.EntityFrameworkCore;

namespace FirstApi.DataBase
{
	public class PgContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(@"Host=localhost:5432;Username=postgres;Password=1234;Database=stock-control");
			base.OnConfiguring(optionsBuilder);
		}
	}
};