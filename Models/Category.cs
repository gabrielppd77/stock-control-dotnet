namespace stock_control_api.Models
{
	public class Category
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
	}
}