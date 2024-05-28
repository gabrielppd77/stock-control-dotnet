using Microsoft.EntityFrameworkCore;
using stock_control_api.Entities;
using stock_control_api.Enums;

namespace stock_control_api.DataBase.Repositories
{
	public class StockRepository
	{
		private readonly PgContext context;

		public StockRepository(PgContext context)
		{
			this.context = context;
		}

		internal async Task<int> CountProductsByStatus(Guid groupId, ProductStatusEnum status)
		{
			return await context.Product
				.Where(x => x.GroupId == groupId)
				.Where(x => x.Status == status)
				.CountAsync();
		}

		internal async Task<List<Group>> GetGroups()
		{
			return await context.Group.ToListAsync();
		}

		internal async Task<List<Product>> GetProducts(Guid groupId)
		{
			return await context.Product.Where(x => x.GroupId == groupId).ToListAsync();
		}
	}
}