namespace stock_control_api.Models
{
	public class GroupModel
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public int Code { get; set; }
	}
}