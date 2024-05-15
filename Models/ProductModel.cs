using stock_control_api.Enums;

namespace stock_control_api.Models
{
	public class ProductModel
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public int Code { get; set; }
		public Guid GroupId { get; set; }
		public Guid SupplierId { get; set; }
		public Guid CategoryId { get; set; }
		public required string NrClient { get; set; }
		public required string Observation { get; set; }
		public ProductStatusEnum Status { get; set; }

		public virtual GroupModel? Group { get; set; }
		public virtual SupplierModel? Supplier { get; set; }
		public virtual CategoryModel? Category { get; set; }
	}
}