using System.ComponentModel.DataAnnotations;

namespace seed_desafio_cdc.API;

public class Author
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public DateTime AtCreated { get; set; }

    public Author()
    {
        AtCreated = DateTime.Now;        
    }
}
