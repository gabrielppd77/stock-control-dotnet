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

		internal async Task AddProduct(Product newProduct)
		{
			await context.AddAsync(newProduct);
		}

		internal async Task<List<Product>> GetAll()
		{
			return await context.Product.AsNoTracking().ToListAsync();
		}

		internal async Task<Product?> GetById(Guid productId)
		{
			return await context.Product.FirstOrDefaultAsync(x => x.Id == productId);
		}

		internal void Remove(Product productFinded)
		{
			context.Remove(productFinded);
		}

		internal async Task SaveChanges()
		{
			await context.SaveChangesAsync();
		}
	}
}