namespace stock_control_api.DTOs
{
	public class GroupCreateDTO
	{
		public Guid SupplierId { get; set; }
		public required string Name { get; set; }
	}
}