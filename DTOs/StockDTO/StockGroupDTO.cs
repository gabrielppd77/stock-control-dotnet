namespace stock_control_api.DTOs
{
	public record StockGroupDTO(Guid Id, int Code, string Name, int AvaiableCount, int PreparingCount, int SoldCount, List<ProductDTO> Products);
}