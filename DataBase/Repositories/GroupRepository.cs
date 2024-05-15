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

		internal async Task AddGroup(Group newGroup)
		{
			await context.AddAsync(newGroup);
		}

		internal async Task<List<Group>> GetAll()
		{
			return await context.Group.AsNoTracking().ToListAsync();
		}

		internal async Task<Group?> GetById(Guid groupId)
		{
			return await context.Group.FirstOrDefaultAsync(x => x.Id == groupId);
		}

		internal void Remove(Group groupFinded)
		{
			context.Remove(groupFinded);
		}

		internal async Task SaveChanges()
		{
			await context.SaveChangesAsync();
		}
	}
}