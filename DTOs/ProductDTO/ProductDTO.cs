using stock_control_api.Enums;

namespace stock_control_api.DTOs
{
	public class ProductDTO
	{
		public Guid Id { get; set; }
		public int Code { get; set; }
		public required string Name { get; set; }
		public Guid GroupId { get; set; }
		public string? NrClient { get; set; }
		public string? Observation { get; set; }
		public ProductStatusEnum Status { get; set; }
	};
}