
using stock_control_api.DataBase.Repositories;
using stock_control_api.DTOs;
using stock_control_api.Entities;

namespace stock_control_api.Services
{
	public class CategoryService
	{
		private readonly CategoryRepository repository;

		public CategoryService(CategoryRepository repository)
		{
			this.repository = repository;
		}

		internal async Task Create(CategoryCreateDTO category)
		{
			var newCategory = new Category()
			{
				Id = Guid.NewGuid(),
				Name = category.Name
			};
			await repository.AddCategory(newCategory);
			await repository.SaveChanges();
		}

		internal async Task<List<CategoryDTO>> GetAll()
		{
			var categories = await repository.GetAll();
			return categories.Select(x => new CategoryDTO(x.Id, x.Name)).ToList();
		}

		internal async Task Remove(Guid categoryId)
		{
			var categoryFinded = await repository.GetById(categoryId);

			if (categoryFinded == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a categoria");
			}

			repository.Remove(categoryFinded);

			await repository.SaveChanges();
		}

		internal async Task Update(Guid categoryId, CategoryUpdateDTO category)
		{
			var categoryFinded = await repository.GetById(categoryId);

			if (categoryFinded == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a categoria");
			}

			categoryFinded.Name = category.Name;

			await repository.SaveChanges();
		}
	}
}