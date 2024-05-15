using Microsoft.AspNetCore.Mvc;
using stock_control_api.DTOs;
using stock_control_api.Services;

namespace stock_control_api
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoryController : ControllerBase
	{
		private readonly CategoryService service;

		public CategoryController(CategoryService service)
		{
			this.service = service;
		}

		[HttpPost]
		public async Task Create(CategoryCreateDTO category)
		{
			await service.Create(category);
		}

		[HttpGet]
		public async Task<List<CategoryDTO>> GetAll()
		{
			return await service.GetAll();
		}

		[HttpPut]
		public async Task Update(Guid categoryId, CategoryUpdateDTO category)
		{
			await service.Update(categoryId, category);
		}

		[HttpDelete]
		public async Task Remove(Guid categoryId)
		{
			await service.Remove(categoryId);
		}
	}
}