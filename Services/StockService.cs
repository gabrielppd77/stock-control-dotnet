using stock_control_api.DataBase.Repositories;
using stock_control_api.DTOs;

namespace stock_control_api.Services
{
	public class StockService
	{
		private readonly StockRepository repository;

		public StockService(StockRepository repository)
		{
			this.repository = repository;
		}

		internal async Task<List<StockGroupDTO>> GetGroups()
		{
			var groups = await repository.GetGroups();

			var stockGroups = new List<StockGroupDTO>();

			foreach (var group in groups)
			{
				var avaiableCount = await repository.CountProductsByStatus(group.Id, Enums.ProductStatusEnum.Available);
				var preparingCount = await repository.CountProductsByStatus(group.Id, Enums.ProductStatusEnum.Preparing);
				var soldCount = await repository.CountProductsByStatus(group.Id, Enums.ProductStatusEnum.Sold);
				var products = await repository.GetProducts(group.Id);

				stockGroups.Add(new StockGroupDTO(group.Id, group.Code, group.Name, avaiableCount, preparingCount, soldCount, products));
			}

			return stockGroups;
		}
	}
}