
using stock_control_api.DataBase.Repositories;
using stock_control_api.DTOs;
using stock_control_api.Models;

namespace stock_control_api.Services
{
	public class CategoryService
	{
		private readonly CategoryRepository repository;

		public CategoryService(CategoryRepository repository)
		{
			this.repository = repository;
		}

		public async Task Create(CategoryCreateDTO category)
		{
			var newCategory = new CategoryModel()
			{
				Id = Guid.NewGuid(),
				Name = category.name
			};
			await repository.AddCategory(newCategory);
			await repository.SaveChanges();
		}

		public async Task<List<CategoryDTO>> GetAll()
		{
			var categories = await repository.GetAll();
			return categories.Select(x => new CategoryDTO(x.Id, x.Name)).ToList();
		}
	}
}