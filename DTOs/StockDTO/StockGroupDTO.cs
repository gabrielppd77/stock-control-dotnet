namespace stock_control_api.DTOs
{
	public class StockGroupDTO
	{
		public Guid Id { get; set; }
		public Guid SupplierId { get; set; }
		public int Code { get; set; }
		public required string Name { get; set; }
		public int AvaiableCount { get; set; }
		public int PreparingCount { get; set; }
		public int SoldCount { get; set; }
		public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
	}
}