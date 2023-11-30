using System.ComponentModel.DataAnnotations;

namespace seed_desafio_cdc.API;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }

    public Category(string? name)
    {
        this.Name = name;
    }
}
