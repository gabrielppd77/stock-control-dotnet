using Microsoft.AspNetCore.Mvc;
using stock_control_api.DTOs;
using stock_control_api.Services;

namespace stock_control_api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SupplierController : ControllerBase
	{
		private readonly SupplierService service;

		public SupplierController(SupplierService service)
		{
			this.service = service;
		}

		[HttpPost]
		public async Task Create(SupplierCreateDTO supplier)
		{
			await service.Create(supplier);
		}

		[HttpGet]
		public async Task<List<SupplierDTO>> GetAll()
		{
			return await service.GetAll();
		}

		[HttpPut]
		public async Task Update(Guid supplierId, SupplierUpdateDTO supplier)
		{
			await service.Update(supplierId, supplier);
		}

		[HttpDelete]
		public async Task Remove(Guid supplierId)
		{
			await service.Remove(supplierId);
		}
	}
}