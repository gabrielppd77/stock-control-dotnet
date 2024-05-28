using System.ComponentModel.DataAnnotations;

public class GuidAttribute : ValidationAttribute
{
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		if ((value is Guid) && Guid.Empty == (Guid)value)
		{
			return new ValidationResult("Guid cannot be empty.");
		}
		return null;
	}
}
