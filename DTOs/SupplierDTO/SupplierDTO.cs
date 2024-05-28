namespace stock_control_api.DTOs
{
	public class SupplierDTO
	{
		public Guid Id { get; set; }
		public int Code { get; set; }
		public required string Name { get; set; }
	}
}