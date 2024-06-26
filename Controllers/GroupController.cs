using Microsoft.AspNetCore.Mvc;
using stock_control_api.DTOs;
using stock_control_api.Services;

namespace stock_control_api
{
	[ApiController]
	[Route("api/[controller]")]
	public class GroupController : ControllerBase
	{
		private readonly GroupService service;

		public GroupController(GroupService service)
		{
			this.service = service;
		}

		[HttpPost]
		public async Task Create(GroupCreateDTO group)
		{
			await service.Create(group);
		}

		[HttpGet]
		public async Task<List<GroupDTO>> GetAll(Guid? supplierId)
		{
			return await service.GetAll(supplierId);
		}

		[HttpPut]
		public async Task Update(Guid groupId, GroupUpdateDTO group)
		{
			await service.Update(groupId, group);
		}

		[HttpDelete]
		public async Task Remove(Guid groupId)
		{
			await service.Remove(groupId);
		}
	}
}