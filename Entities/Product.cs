using stock_control_api.Enums;

namespace stock_control_api.Entities
{
	public class Product
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public int Code { get; set; }
		public Guid GroupId { get; set; }
		public Guid SupplierId { get; set; }
		public Guid CategoryId { get; set; }
		public string? NrClient { get; set; }
		public string? Observation { get; set; }
		public ProductStatusEnum Status { get; set; }

		public virtual Group? Group { get; set; }
		public virtual Supplier? Supplier { get; set; }
		public virtual Category? Category { get; set; }
	}
}