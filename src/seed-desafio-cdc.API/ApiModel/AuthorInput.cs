using System.ComponentModel.DataAnnotations;

namespace seed_desafio_cdc.API;

public class AuthorInput
{
    [Required(AllowEmptyStrings = false)]    
    public string? name { get; set; }

    [Required(AllowEmptyStrings = false)]    
    [StringLength(maximumLength: 400)]
    public string? description { get; set; }
    
    [Required(AllowEmptyStrings = false)] 
    [UniqueValue("email", typeof(Author))]
    public string? emailAddress { get; set; }

    public AuthorInput(string name, string description, string emailAddress)
    {
        this.name = name;
        this.description = description;
        this.emailAddress = emailAddress;
    }

    public Author toModel(){
        return new Author( name: name, email: emailAddress , description: description);
    }
}