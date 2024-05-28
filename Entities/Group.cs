namespace stock_control_api.Entities
{
	public class Group
	{
		public Guid Id { get; set; }
		public int Code { get; set; }
		public required string Name { get; set; }
		public Guid SupplierId { get; set; }
		public virtual Supplier? Supplier { get; set; }
	}
}