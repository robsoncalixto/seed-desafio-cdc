using System.ComponentModel.DataAnnotations;

namespace seed_desafio_cdc.API;

public class BookInput
{
    [Required(AllowEmptyStrings = false)]
    [UniqueValue(nameof(Book.Title),typeof(Book))]
    public string? Title { get; set; }

    [Required(AllowEmptyStrings = false)]
    [MaxLength(500)]
    public string? Abstract { get; set; }
    public string? Summary { get; set; }
    
    [Range(20.0, (double)decimal.MaxValue)]
    public decimal Price { get; set; }  
    
    [Required(AllowEmptyStrings = false)]
    [UniqueValue(nameof(Book.Isbn),typeof(Book))]
    public string? Isbn { get; set; }

    [MinLength(length: 100)]
    public int NumberOfPages { get; set; }

    public DateTime Release { get; set; }
    
    [Required(AllowEmptyStrings = false)]
    public int AuthorId { get; set; }
    
    [Required(AllowEmptyStrings = false)]
    public int CategoryId { get; set; }
}
