using System.ComponentModel.DataAnnotations;


namespace seed_desafio_cdc.API;
public class UniqueValue : ValidationAttribute
{
    public string Field { get; }
    public Type ClassName { get; set; }


    // construnctor recieve the property name and class name
    public UniqueValue(string propertyName, Type className)
    {
        this.Field = propertyName;
        this.ClassName = className;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        var context = (DbContextPostgres)validationContext.GetService(typeof(DbContextPostgres));
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.        

        var property = validationContext.ObjectType.GetProperty(Field);
        var propertyValue = property?.GetValue(validationContext.ObjectInstance, null);
        var fieldValue = value?.ToString();

        string nameClass = ClassName!.Name;
        switch (nameClass)
        {
            case nameof(Author):
                var author = context!.Authors.Where(a => a.Email == fieldValue).FirstOrDefault();                               
                if (author != null )
                {
                    return new ValidationResult($"{Field} already exists.");
                }
                break;
            case nameof(Category):
                var category = context!.Categories.Where(c => c.Name == fieldValue).FirstOrDefault();
                if (category != null)
                {
                    return new ValidationResult($"{Field} already exists.");
                }
                break;
            default:
                break;
        }
        return ValidationResult.Success!;
    }
}
