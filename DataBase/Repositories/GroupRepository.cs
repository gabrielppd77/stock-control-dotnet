using Microsoft.EntityFrameworkCore;
using stock_control_api.Entities;

namespace stock_control_api.DataBase.Repositories
{
	public class GroupRepository
	{
		private readonly PgContext context;

		public GroupRepository(PgContext context)
		{
			this.context = context;
		}

		internal async Task<int> GetLastCode()
		{
			return await context.Group
				.OrderBy(x => x.Code)
				.Select(x => x.Code)
				.LastOrDefaultAsync();
		}

		internal async Task AddGroup(Group newGroup)
		{
			await context.Group.AddAsync(newGroup);
		}

		internal async Task<List<Group>> GetAll(Guid? supplierId)
		{
			var query = context.Group.AsQueryable();

			if (supplierId != null)
			{
				query = query.Where(x => x.SupplierId == supplierId);
			}

			return await query.OrderBy(x => x.Code).ToListAsync();
		}

		internal async Task<Group?> GetById(Guid groupId)
		{
			return await context.Group.FirstOrDefaultAsync(x => x.Id == groupId);
		}

		internal void Remove(Group groupFinded)
		{
			context.Group.Remove(groupFinded);
		}

		internal async Task SaveChanges()
		{
			await context.SaveChangesAsync();
		}
	}
}