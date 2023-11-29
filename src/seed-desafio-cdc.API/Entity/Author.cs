using System.ComponentModel.DataAnnotations;

namespace seed_desafio_cdc.API;

public class Author
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public DateTime AtCreated = DateTime.Now;
    
    public Author(string? name, string? email, string? description)
    {
        Name = name;
        Email = email;
        Description = description;
    }
}
