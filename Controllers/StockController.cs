using Microsoft.AspNetCore.Mvc;
using stock_control_api.DTOs;
using stock_control_api.Enums;
using stock_control_api.Services;

namespace stock_control_api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class StockController : ControllerBase
	{
		private readonly StockService service;

		public StockController(StockService service)
		{
			this.service = service;
		}

		[HttpGet("GetGroups")]
		public async Task<List<StockGroupDTO>> GetGroups(Guid? supplierId)
		{
			return await service.GetGroups(supplierId);
		}

		[HttpPost("GetProducts")]
		public async Task<List<ProductDTO>> GetProducts(Guid groupId, List<ProductStatusEnum> status)
		{
			return await service.GetProducts(groupId, status);
		}
	}
}