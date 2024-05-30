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

		internal async Task<List<Group>> GetGroups(Guid? supplierId)
		{
			var query = context.Group.AsQueryable();

			if (supplierId != null)
			{
				query = query.Where(x => x.SupplierId == supplierId);
			}

			return await query.OrderBy(x => x.Code).ToListAsync();
		}

		internal async Task<List<Product>> GetProducts(Guid groupId)
		{
			return await context.Product
				.Where(x => x.GroupId == groupId)
				.OrderBy(x => x.Code)
				.ToListAsync();
		}
	}
}