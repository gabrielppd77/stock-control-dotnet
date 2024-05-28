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

				stockGroups.Add(new StockGroupDTO()
				{
					Id = group.Id,
					SupplierId = group.SupplierId,
					Code = group.Code,
					Name = group.Name,
					AvaiableCount = avaiableCount,
					PreparingCount = preparingCount,
					SoldCount = soldCount,
					Products = products.Select(x => new ProductDTO()
					{
						Id = x.Id,
						Code = x.Code,
						Name = x.Name,
						GroupId = x.GroupId,
						NrClient = x.NrClient,
						Observation = x.Observation,
						Status = x.Status,
					}).ToList()
				});
			}

			return stockGroups;
		}
	}
}