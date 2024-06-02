using stock_control_api.DataBase.Repositories;
using stock_control_api.DTOs;
using stock_control_api.Enums;

namespace stock_control_api.Services
{
	public class StockService
	{
		private readonly StockRepository repository;

		public StockService(StockRepository repository)
		{
			this.repository = repository;
		}

		internal async Task<List<StockGroupDTO>> GetGroups(Guid? supplierId)
		{
			var groups = await repository.GetGroups(supplierId);

			var stockGroups = new List<StockGroupDTO>();

			foreach (var group in groups)
			{
				var avaiableCount = await repository.CountProductsByStatus(group.Id, Enums.ProductStatusEnum.Available);
				var preparingCount = await repository.CountProductsByStatus(group.Id, Enums.ProductStatusEnum.Preparing);
				var soldCount = await repository.CountProductsByStatus(group.Id, Enums.ProductStatusEnum.Sold);

				stockGroups.Add(new StockGroupDTO()
				{
					Id = group.Id,
					SupplierId = group.SupplierId,
					Code = group.Code,
					Name = group.Name,
					AvaiableCount = avaiableCount,
					PreparingCount = preparingCount,
					SoldCount = soldCount,
				});
			}

			return stockGroups;
		}

		internal async Task<List<ProductDTO>> GetProducts(Guid groupId, List<ProductStatusEnum> status)
		{
			var products = await repository.GetProducts(groupId, status);
			return products.Select(x => new ProductDTO()
			{
				Id = x.Id,
				Code = x.Code,
				Name = x.Name,
				GroupId = x.GroupId,
				NrClient = x.NrClient,
				Observation = x.Observation,
				Status = x.Status,
			}).ToList();
		}
	}
}