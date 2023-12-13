using System.ComponentModel.DataAnnotations;

namespace seed_desafio_cdc.API;

public class BookInput
{
    [Required(AllowEmptyStrings = false)]
    [UniqueValue(nameof(Book.Title),typeof(Book))]
    public string? Title { get; set; }
    
    public string? Abstract { get; set; }

    public string? Summary { get; set; }
    public string? Isbn { get; set; }
    public decimal Price { get; set; }   
    public DateTime Release { get; set; }

}
