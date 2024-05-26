
using stock_control_api.DataBase.Repositories;
using stock_control_api.DTOs;
using stock_control_api.Entities;

namespace stock_control_api.Services
{
	public class GroupService
	{
		private readonly GroupRepository repository;

		public GroupService(GroupRepository repository)
		{
			this.repository = repository;
		}

		internal async Task Create(GroupCreateDTO group)
		{
			var newGroup = new Group()
			{
				Id = Guid.NewGuid(),
				Name = group.Name,
				Code = await repository.GetLastCode()
			};
			await repository.AddGroup(newGroup);
			await repository.SaveChanges();
		}

		internal async Task<List<GroupDTO>> GetAll()
		{
			var categories = await repository.GetAll();
			return categories.Select(x => new GroupDTO(x.Id, x.Code, x.Name)).ToList();
		}

		internal async Task Remove(Guid groupId)
		{
			var groupFinded = await repository.GetById(groupId);

			if (groupFinded == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar o grupo");
			}

			repository.Remove(groupFinded);

			await repository.SaveChanges();
		}

		internal async Task Update(Guid groupId, GroupUpdateDTO group)
		{
			var groupFinded = await repository.GetById(groupId);

			if (groupFinded == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar o grupo");
			}

			groupFinded.Name = group.Name;
			groupFinded.Code = group.Code;

			await repository.SaveChanges();
		}
	}
}