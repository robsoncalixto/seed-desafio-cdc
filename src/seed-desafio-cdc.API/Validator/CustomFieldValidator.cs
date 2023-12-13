using System.ComponentModel.DataAnnotations;

namespace seed_desafio_cdc.API;

public class CustomFieldValidator : ValidationAttribute
{
     protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        var context = (DbContextPostgres)validationContext.GetService(typeof(DbContextPostgres));
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
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
