namespace stock_control_api.DTOs
{
	public class GroupUpdateDTO
	{
		public Guid SupplierId { get; set; }
		public int Code { get; set; }
		public required string Name { get; set; }
	};
}