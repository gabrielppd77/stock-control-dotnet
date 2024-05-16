using stock_control_api.Enums;

namespace stock_control_api.DTOs
{
	public record ProductDTO(
		Guid Id,
		string Name,
		int Code,
		Guid GroupId,
		Guid SupplierId,
		Guid CategoryId,
		string? NrClient,
		string? Observation,
		ProductStatusEnum Status
	);
}