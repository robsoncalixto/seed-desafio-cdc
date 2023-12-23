using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace seed_desafio_cdc.API;

public class Book
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Abstract { get; set; }
    public string? Summary { get; set; }
    public decimal Price { get; set; }
    public int Pages { get; set; }
    public string? Isbn { get; set; }
    public DateTime Release { get; set; }
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }

    [ForeignKey("AuthorId")]
    public Category? Category { get; set; }

    [ForeignKey("CategoryId")]
    public Author? Author { get; set; }    
}
