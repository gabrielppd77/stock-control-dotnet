namespace stock_control_api.DTOs
{
	public record ProductCreateDTO(
		string Name,
		int Code,
		Guid GroupId,
		Guid SupplierId,
		Guid CategoryId,
		string? NrClient,
		string? Observation
	);
}