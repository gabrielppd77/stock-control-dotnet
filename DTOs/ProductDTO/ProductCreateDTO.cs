namespace stock_control_api.DTOs
{
	public class ProductCreateDTO
	{
		public required string Name { get; set; }
		public Guid GroupId { get; set; }
		public string? NrClient { get; set; }
		public string? Observation { get; set; }
	};
}