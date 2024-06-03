using Microsoft.AspNetCore.Mvc;
using stock_control_api.DTOs;
using stock_control_api.Services;

namespace stock_control_api
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly ProductService service;

		public ProductController(ProductService service)
		{
			this.service = service;
		}

		[HttpPost]
		public async Task Create(ProductCreateDTO product)
		{
			await service.Create(product);
		}

		[HttpPut]
		public async Task Update(Guid productId, ProductUpdateDTO product)
		{
			await service.Update(productId, product);
		}

		[HttpDelete]
		public async Task Remove(Guid productId)
		{
			await service.Remove(productId);
		}

		[HttpPost("MultiplyProduct")]
		public async Task MultiplyProduct(Guid productId, int quantity)
		{
			await service.MultiplyProduct(productId, quantity);
		}
	}
}