using Microsoft.EntityFrameworkCore;
using stock_control_api.Entities;

namespace stock_control_api.DataBase.Repositories
{
	public class ProductRepository
	{
		private readonly PgContext context;

		public ProductRepository(PgContext context)
		{
			this.context = context;
		}

		internal async Task<int> GetLastCode()
		{
			return await context.Product
				.OrderBy(x => x.Code)
				.Select(x => x.Code)
				.LastOrDefaultAsync();
		}

		internal async Task AddProduct(Product newProduct)
		{
			await context.Product.AddAsync(newProduct);
		}

		internal async Task<List<Product>> GetAll()
		{
			return await context.Product.AsNoTracking().OrderBy(x => x.Code).ToListAsync();
		}

		internal async Task<Product?> GetById(Guid productId)
		{
			return await context.Product.FirstOrDefaultAsync(x => x.Id == productId);
		}

		internal void Remove(Product productFinded)
		{
			context.Product.Remove(productFinded);
		}

		internal async Task SaveChanges()
		{
			await context.SaveChangesAsync();
		}
	}
}