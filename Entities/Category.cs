namespace stock_control_api.Entities
{
	public class Category
	{
		public Guid Id { get; set; }
		public int Code { get; set; }
		public required string Name { get; set; }
	}
}