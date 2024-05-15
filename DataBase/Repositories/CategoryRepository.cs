using FirstApi.DataBase;
using Microsoft.EntityFrameworkCore;
using stock_control_api.Entities;

namespace stock_control_api.DataBase.Repositories
{
	public class CategoryRepository
	{
		private readonly PgContext context;

		public CategoryRepository(PgContext context)
		{
			this.context = context;
		}

		internal async Task AddCategory(Category newCategory)
		{
			await context.AddAsync(newCategory);
		}

		internal async Task<List<Category>> GetAll()
		{
			return await context.Category.AsNoTracking().ToListAsync();
		}

		internal async Task<Category?> GetById(Guid categoryId)
		{
			return await context.Category.FirstOrDefaultAsync(x => x.Id == categoryId);
		}

		internal void Remove(Category categoryFinded)
		{
			context.Remove(categoryFinded);
		}

		internal async Task SaveChanges()
		{
			await context.SaveChangesAsync();
		}
	}
}