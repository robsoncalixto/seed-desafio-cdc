using Microsoft.AspNetCore.Mvc;

namespace seed_desafio_cdc.API;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
 

    [HttpPost]
    public async Task<IActionResult> Create([FromServices] IAuthorRepository repository, [FromBody] AuthorInput input)
    {   
        var emailExisting = await repository.FindByEmailAsync(input.emailAddress!);        
        if(emailExisting != null){
            ModelState.AddModelError("Email", "Email already exists.");
            return  BadRequest(ModelState);
        }       
        return Ok(await repository.SaveAsync(input.toModel()));
    }

    [HttpGet]
    public async Task<IActionResult> List([FromServices] IAuthorRepository repository ){
        return Ok(await repository.ListAsync());
    }
}
