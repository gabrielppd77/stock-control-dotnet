namespace stock_control_api.DTOs
{
	public class StockGroupDTO : GroupDTO
	{
		public int AvaiableCount { get; set; }
		public int PreparingCount { get; set; }
		public int SoldCount { get; set; }
	}
}