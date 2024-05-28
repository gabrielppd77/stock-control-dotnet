using Microsoft.AspNetCore.Mvc;
using stock_control_api.DTOs;
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

		[HttpGet()]
		public async Task<List<StockGroupDTO>> GetGroups()
		{
			return await service.GetGroups();
		}
	}
}