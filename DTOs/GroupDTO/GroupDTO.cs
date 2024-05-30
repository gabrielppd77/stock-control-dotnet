namespace stock_control_api.DTOs
{
	public class GroupDTO
	{
		public Guid Id { get; set; }
		public Guid SupplierId { get; set; }
		public int Code { get; set; }
		public required string Name { get; set; }
	}
}