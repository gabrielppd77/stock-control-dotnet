using FirstApi.DataBase;
using Microsoft.EntityFrameworkCore;
using stock_control_api.DTOs;
using stock_control_api.Models;

namespace stock_control_api.DataBase.Repositories
{
	public class CategoryRepository
	{
		private readonly PgContext context;

		public CategoryRepository(PgContext context)
		{
			this.context = context;
		}

		public async Task AddCategory(CategoryModel newCategory)
		{
			await context.AddAsync(newCategory);
		}

		public async Task<List<CategoryModel>> GetAll()
		{
			return await context.Category.AsNoTracking().ToListAsync();
		}

		internal async Task SaveChanges()
		{
			await context.SaveChangesAsync();
		}
	}
}