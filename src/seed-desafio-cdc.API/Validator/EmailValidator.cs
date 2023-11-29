using System.ComponentModel.DataAnnotations;

namespace seed_desafio_cdc.API;

public class EmailValidator : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var email = value?.ToString();
        if (string.IsNullOrWhiteSpace(email))
        {
            return new ValidationResult("Email is required.");
        }

        if (!new EmailAddressAttribute().IsValid(email))
        {
            return new ValidationResult("Email is invalid.");
        }

        return ValidationResult.Success!;
    }
}
