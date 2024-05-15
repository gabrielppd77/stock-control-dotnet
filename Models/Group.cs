namespace stock_control_api.Models
{
	public class Group
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public int Code { get; set; }
	}
}